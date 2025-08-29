const IDENTITY_SERVER_URL = 'https://localhost:7125'; // URL do seu IdentityServer
const CLIENT_ID = 'ropc.client'; // ID do cliente ROPC configurado no IdentityServer
const CLIENT_SECRET = 'secret'; // Segredo do cliente ROPC (NUNCA EXPOR EM PROD!)

class AuthServiceROPC {

    constructor() {
        this.accessToken = localStorage.getItem('access_token');
        this.refreshToken = localStorage.getItem('refresh_token');
        this.idToken = localStorage.getItem('id_token');
        const storedProfile = localStorage.getItem('user_profile');
        this.userProfile = storedProfile ? JSON.parse(storedProfile) : null;
    }

    async Postlogin(username, password) {
        const params = new URLSearchParams();
        params.append('grant_type', 'password');
        params.append('client_id', CLIENT_ID);
        params.append('client_secret', CLIENT_SECRET);
        params.append('username', username);
        params.append('password', password);
      //  params.append('scope', 'openid profile Email api1 offline_access');

        const requestOptions = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            body: params.toString()
        };

        try {
            const response = await fetch(`${IDENTITY_SERVER_URL}/connect/token`, requestOptions);

            if (!response.ok) {
                const errorData = await response.json();
                console.error('Erro ao obter token:', errorData);
                throw new Error(errorData.error_description || errorData.error || 'Falha ao obter token');
            }

            const tokenData = await response.json();

            // Armazenar os tokens recebidos e atualizar a instância da classe
            this.accessToken = tokenData.access_token;
            this.refreshToken = tokenData.refresh_token;
            this.idToken = tokenData.id_token;

            localStorage.setItem('access_token', tokenData.access_token);
            if (tokenData.refresh_token) {
                localStorage.setItem('refresh_token', tokenData.refresh_token);
            }
            if (tokenData.id_token) {
                localStorage.setItem('id_token', tokenData.id_token);
            }

            const userInfo = await this.getUserInfo(tokenData.access_token);
            this.userProfile = userInfo;
            
            localStorage.setItem('user_profile', JSON.stringify(userInfo));

            return { ...tokenData, profile: userInfo };

        } catch (error) {
            console.error('Erro durante o login ROPC:', error);
            throw error;
        }
    }

    async getUserInfo(accessToken) {
        try {
            const response = await fetch(`${IDENTITY_SERVER_URL}/connect/userinfo`, {
                method: 'GET',
                headers: {
                    'Authorization': `Bearer ${accessToken}`
                }
            });

            if (!response.ok) {
                const errorData = await response.json();
                console.error('Erro ao obter informações do usuário:', errorData);
                throw new Error(errorData.error_description || 'Falha ao obter informações do usuário');
            }

            const userInfo = await response.json();
            console.log('Informações do usuário recebidas:', userInfo);
            return userInfo;
        } catch (error) {
            console.error('Erro ao buscar informações do usuário:', error);
            throw error;
        }
    }

    // Método auxiliar para revogação
    async revokeToken(token, tokenTypeHint) { // Removidos tipos e 'private'
        const params = new URLSearchParams();
        params.append('client_id', CLIENT_ID);
        params.append('client_secret', CLIENT_SECRET);
        params.append('token', token);
        params.append('token_type_hint', tokenTypeHint);

        try {
            const response = await fetch(`${IDENTITY_SERVER_URL}/connect/revocation`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded'
                },
                body: params.toString()
            });

            if (!response.ok) {
                const errorData = await response.json().catch(() => ({}));
                console.error(`Erro ao revogar ${tokenTypeHint}:`, response.status, response.statusText, errorData);
                throw new Error(`Falha na revogação do ${tokenTypeHint}: ${response.statusText}`);
            }

            console.log(`${tokenTypeHint} revogado com sucesso.`);
        } catch (error) {
            console.error(`Erro de rede ou inesperado ao revogar ${tokenTypeHint}:`, error);
        }
    }

    async logout() {
        if (this.refreshToken) {
            console.log("Tentando revogar Refresh Token...");
            await this.revokeToken(this.refreshToken, 'refresh_token')
                .catch(err => console.warn("Falha na revogação do Refresh Token (pode não ser crítico):", err));
        }

        if (this.accessToken) {
            console.log("Tentando revogar Access Token...");
            await this.revokeToken(this.accessToken, 'access_token')
                .catch(err => console.warn("Falha na revogação do Access Token (pode não ser crítico):", err));
        }

        localStorage.removeItem('access_token');
        localStorage.removeItem('refresh_token');
        localStorage.removeItem('id_token');
        localStorage.removeItem('user_profile');

        this.accessToken = null;
        this.refreshToken = null;
        this.idToken = null;
        this.userProfile = null;

        console.log("Tokens e perfil do usuário removidos localmente.");
    }

    getAccessToken() {
        return this.accessToken;
    }

    getRefreshToken() {
        return this.refreshToken;
    }

    getIdToken() {
        return this.idToken;
    }

    getUserProfile() {
        return this.userProfile;
    }

    isAuthenticated() {
        return !!this.accessToken;
    }
}
  /*  localStorage.removeItem('access_token');
    localStorage.removeItem('refresh_token');
    localStorage.removeItem('id_token');
    localStorage.removeItem('user_profile');
    // Em alguns casos, você pode querer chamar o endpoint de revogação de token do IdentityServer
    return fetch(`${IDENTITY_SERVER_URL}/connect/revocation`, { ... });*/
  
  


/*class AuthServiceROPC {
  // Função para fazer login via ROPC
  async Postlogin(email, password) {
    const params = new URLSearchParams();
    params.append('grant_type', 'password');
    params.append('client_id', CLIENT_ID);
    params.append('client_secret', CLIENT_SECRET);
    params.append('scope', 'openid profile api1'); // Escopos que você quer (adapte conforme sua configuração)
    params.append('username', email); // O e-mail do usuário como username
    params.append('password', password);

    try {
      const response = await fetch(`${IDENTITY_SERVER_URL}/connect/token`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/x-www-form-urlencoded'
        },
        body: params.toString()
      });

      if (!response.ok) {
        const errorData = await response.json();
        console.error('Error getting token:', errorData);
        throw new Error(errorData.error_description || 'Failed to get token');
      }

      const tokenData = await response.json();
      console.log('Token data received:', tokenData);

      // Armazene os tokens (ex: localStorage - considere os riscos de segurança)
      localStorage.setItem('access_token', tokenData.access_token);
      if (tokenData.refresh_token) {
        localStorage.setItem('refresh_token', tokenData.refresh_token);
      }
      // Se houver id_token, armazene-o também
      if (tokenData.id_token) {
        localStorage.setItem('id_token', tokenData.id_token);
      }

      // Agora, obtenha as claims do UserInfo Endpoint
      const userInfo = await this.getUserInfo(tokenData.access_token);
      localStorage.setItem('user_profile', JSON.stringify(userInfo));

      return { ...tokenData, profile: userInfo };

    } catch (error) {
      console.error('Login error:', error);
      throw error;
    }
  }

  // Função para obter as informações do usuário do UserInfo Endpoint
  async getUserInfo(accessToken) {
    try {
      const response = await fetch(`${IDENTITY_SERVER_URL}/connect/userinfo`, {
        method: 'GET',
        headers: {
          'Authorization': `Bearer ${accessToken}`
        }
      });

      if (!response.ok) {
        const errorData = await response.json();
        console.error('Error getting user info:', errorData);
        throw new Error(errorData.error_description || 'Failed to get user info');
      }

      const userInfo = await response.json();
      console.log('User info received:', userInfo);
      return userInfo;
    } catch (error) {
      console.error('Error fetching user info:', error);
      throw error;
    }
  }

  // Função para verificar se o usuário está logado
  async getCurrentUser() {
    const accessToken = localStorage.getItem('access_token');
    const userProfile = localStorage.getItem('user_profile');

    if (accessToken && userProfile) {
      // Opcional: Validar o token de acesso no backend ou tentar renová-lo
      return {
        access_token: accessToken,
        profile: JSON.parse(userProfile)
      };
    }
    return null;
  }

  // Função para fazer logout (apenas limpar os tokens no cliente)
 
} */

const authServiceROPC = new AuthServiceROPC();
export default authServiceROPC;

/* 
export function Postlogin(username,password){
  const params = new URLSearchParams();
  params.append('grant_type', 'password');
  params.append('client_id', 'ropc.client');
  params.append('client_secret', 'secret');
  params.append('username', username);
  params.append('password', password);

const requestOptions = {
    method: 'POST',
    headers: {
      'Content-Type': 'application/x-www-form-urlencoded'
    },
    body: params
  };
  return fetch('https://localhost:7125/connect/token', requestOptions)
    .then(response => response.json())
    .then(data => {
      const token = data.access_token;
      localStorage.setItem('token', JSON.stringify(token));
    //  localStorage.setItem('token', token);
    //  const userInfo = await this.getUserInfo(tokenData.access_token);
    //  localStorage.setItem('user_profile', JSON.stringify(userInfo));

      window.location.href = '/home';
      return data;
    });

}
 */
