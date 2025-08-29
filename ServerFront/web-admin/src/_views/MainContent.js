import React from 'react';

function MainContent({ isSidebarCollapsed, children }) { // Receba 'children' como prop
    return (
        <div className="main-content p-9">
            <div className="container-fluid">
                {children} {/* Renderiza o conteúdo da rota aqui */}


            </div>
        </div>
    );
}

export default MainContent;