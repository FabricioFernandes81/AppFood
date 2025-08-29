import React,{useState,useEffect, useRef} from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faChevronLeft, faChevronRight,faBars} from '@fortawesome/free-solid-svg-icons';
import '@fortawesome/fontawesome-free/css/all.min.css';
import { Dropdown } from 'bootstrap';

const NavBar =({onToggleSidebar, isCollapsed,profile})=> {
  const [isdropShow, setIsDropShow] = useState(false);

  const toggleDrop = () => {
    setIsDropShow(prev => !prev);
  };
   
    return(
     <nav id="navbar" className="navbar">
            <div className="container-fluid d-flex justify-content-between align-items-center">
                <button id="sidebarToggle" className="navbar-toggler" type="button" onClick={onToggleSidebar}>
                    <i className="fas fa-bars"></i>
                </button>

                {/* Campo de busca */}
                <div className="input-group flex-grow-1 mx-3" style={{ maxWidth: '400px' }}>
                    <span className="input-group-text"><i className="fas fa-search"></i></span>
                    <input type="text" className="form-control" placeholder="Search here..." />
                </div>

                {/* Ícones da direita da navbar */}
                <ul className="navbar-nav flex-row">
                    <li className="nav-item me-3">
                        <a className="nav-link" href="#">
                            <i className="fas fa-bell position-relative">
                                <span className="position-absolute top-0 start-100 translate-middle badge rounded-pill bg-danger" style={{ fontSize: '0.6em' }}>
                                    4
                                    <span className="visually-hidden">unread messages</span>
                                </span>
                            </i>
                        </a>
                    </li>
                    <li className="nav-item dropdown ">
                        
                        <a className="nav-link dropdown-toggle d-flex align-items-center dkPRJL" onClick={toggleDrop} id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                            <img src="data:image/png;base64,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" alt="Perfil" className="rounded-circle me-2" />
                            <span className="d-none d-lg-block ">{profile?.email}</span>
                        </a>
                        <ul className= {`dropdown-menu dropdown-menu-end  ${isdropShow ? "show" : ""}`} aria-labelledby="navbarDropdown">
                            <li><a className="dropdown-item" href="#">Perfil</a></li>
                            <li><a className="dropdown-item" href="#">Configurações</a></li>
                            <li><hr className="dropdown-divider" /></li>
                            <li><a className="dropdown-item" href="#">Sair</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </nav>
    )
}

export default NavBar;