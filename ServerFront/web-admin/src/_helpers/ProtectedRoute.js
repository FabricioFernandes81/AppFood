/* import React from 'react';
import { Navigate, useLocation } from 'react-router-dom';
import { history } from './history';

function ProtectedRoute({ children }) {
  const location = useLocation();
  const token = localStorage.getItem('access_token');
  const profile = localStorage.getItem('user_profile');
  if (!token && !profile) {
    console.log("Usuário não autenticado. Redirecionando...", location);
      return <Navigate to="/login" state={{ from: history.location }} />;
  }

  return children;
}

export default ProtectedRoute; */
import React from 'react';
import { useSelector } from 'react-redux';
import { Navigate, Outlet } from 'react-router-dom';

const ProtectedRoute = ({ children }) => {
    
    const isAuthenticated = useSelector((state) => state.Authenticacao.isAuthenticated);
    const loading = useSelector((state) => state.Authenticacao.loading);

    if (loading) {
    
        return <div>Carregando autenticação...</div>;
    }

    if (!isAuthenticated) {
 
        return <Navigate to="/login" replace />;
    }


    return children ? children : <Outlet />;
};

export default ProtectedRoute;