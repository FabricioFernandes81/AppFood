import React,{useState,useEffect} from 'react';
import { Route,Routes, useLocation, useNavigate,Navigate } from 'react-router';
import './App.css';
import './assets/css/formLogin.css'
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js'
import {Home, Performance,Preventive,Orders,Reviews,MerchantProfile, MenuCardapio ,
   AdicionarCategoria,TypeCategoria} from './_views/pages';
import { history } from './_helpers/history';
import { Login } from './_views/login';
import './assets/css/styleInicial.css'
import ProtectedRoute from "./_helpers/ProtectedRoute"
import { startLogout } from './_actions/authentication.action';
import { GetMerchants } from './_actions/merchats.action';
import { connect } from "react-redux";
import Sidebar from './_components/Sidebar';
import NavBar from './_components/Navbar';
import MainContent from './_views/MainContent';

function App(props) {
const {startLogout,isAuthenticated,GetMerchants,profile} = props;
 const location = useLocation();
 const navigate = useNavigate();
 const isLoginPage = location.pathname.startsWith('/login');

   history.navigate = navigate;
   history.location = location;
      const [isSidebarCollapsed, setIsSidebarCollapsed] = useState(false);

    // Função que será passada para o Navbar para alternar a sidebar
    const toggleSidebar = () => {
        setIsSidebarCollapsed(prevState => !prevState);
    };

    // Efeito para gerenciar a classe 'sidebar-collapsed' no <body>
    useEffect(() => {
        if (isSidebarCollapsed) {
            document.body.classList.add('sidebar-collapsed');
        } else {
            document.body.classList.remove('sidebar-collapsed');
        }
    }, [isSidebarCollapsed]);

    // Efeito para responsividade no carregamento e redimensionamento
    useEffect(() => {
        const handleResize = () => {
            if (window.innerWidth <= 768) {
                setIsSidebarCollapsed(true);
            } else {
                // Decide se expande ou mantém colapsada em telas maiores
                // Aqui, vou expandir se for maior que 768px por padrão
                setIsSidebarCollapsed(false);
            }
        };

        // Define o estado inicial com base no tamanho da tela
        handleResize();

        window.addEventListener('resize', handleResize);
        return () => {
            window.removeEventListener('resize', handleResize);
        };
    }, []); // Array de dependências vazio para rodar apenas uma vez na montagem

   const handleLogonOff = ()=> {
         startLogout();
   }
  
  return (
    <div className="App">
      {isLoginPage ? (
       
        <Routes>
          <Route path="/login" element={<Login/>} />
        </Routes>
        ):(
    <div>
    <Sidebar isCollapsed={isSidebarCollapsed} handleLogonOff={handleLogonOff}/>

      <NavBar onToggleSidebar={toggleSidebar} 
      isCollapsed={isSidebarCollapsed}
      profile={profile}
      />

       <MainContent isSidebarCollapsed={isSidebarCollapsed}>
       <Routes>
             <Route path="/home" element={ <ProtectedRoute><Home/></ProtectedRoute>}/>
             <Route path="/performace" element={ <ProtectedRoute><Performance/></ProtectedRoute>}/>
             <Route path="/preventive" element={ <ProtectedRoute><Preventive/></ProtectedRoute>}/>
             <Route path="/orders" element={ <ProtectedRoute><Orders/></ProtectedRoute>}/>
             <Route path="/reviews" element={ <ProtectedRoute><Reviews/></ProtectedRoute>}/>
             <Route path="/menu/list" element={ <ProtectedRoute><MenuCardapio/></ProtectedRoute>}/>
             <Route path='/merchant/profile' element= {<ProtectedRoute><MerchantProfile tabActive= {null}/></ProtectedRoute>}/>
             <Route path='/merchant/profile/address' element= {<ProtectedRoute><MerchantProfile tabActive = {'overlay-dark'}/></ProtectedRoute>}/>
             <Route path='/merchant/profile/address/edit' element= {<ProtectedRoute><MerchantProfile tabActive = {'overlay-dark'}/></ProtectedRoute>}/>
             <Route path="/menu/catalogs" element={ <ProtectedRoute>< AdicionarCategoria/></ProtectedRoute>}/>
             <Route path="/menu/category/:id?" element={ <ProtectedRoute><TypeCategoria/></ProtectedRoute>}/>

            
             <Route path="*" element={<ProtectedRoute><Navigate to="/home" /></ProtectedRoute>} />
          
           </Routes> 
       </MainContent>
   
  </div>
        )}
    </div>
    
  );
}
const mapStateToProps = state => {

  return {
  isAuthenticated: state.Authenticacao.isAuthenticated,
  profile: state.Authenticacao.user,
  }
}

function mapDispatchToProps (dispatch) {
  return{
    startLogout:() => dispatch(startLogout()),
    GetMerchants:() => dispatch(GetMerchants()),
  };
}

const ConectApp = connect(mapStateToProps,mapDispatchToProps)(App);

export { ConectApp as App };
