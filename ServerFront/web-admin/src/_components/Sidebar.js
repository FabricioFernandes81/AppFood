import React, { useState, useEffect, useRef } from 'react';
import { Tooltip } from 'bootstrap';
import { connect } from "react-redux";
import { GetMerchants, setSelectedMerchant } from '../_actions/merchats.action';
import { NavLink,Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faChevronLeft, faChevronRight, faBars } from '@fortawesome/free-solid-svg-icons';
import 'bootstrap/dist/js/bootstrap.bundle.min';

const Sidebar = ({ isCollapsed, handleLogonOff
  ,isAuthenticated,GetMerchants,merchants,selectedMerchant,setSelectedMerchant}) => {
  const sidebarRef = useRef(null);
  const [isDropdownOpen,setIsDropdownOpen] = useState(false);
  const tooltipInstances = useRef([]); 
  // const {isAuthenticated, GetMerchants} = props;
  
  useEffect(() => {
    if (sidebarRef.current) {
      const tooltipTriggerList = Array.from(sidebarRef.current.querySelectorAll('[data-bs-toggle="tooltip"]'));

      tooltipInstances.current = tooltipTriggerList.map(tooltipTriggerEl => {
        return new Tooltip(tooltipTriggerEl);
      });
    }

    return () => {
      tooltipInstances.current.forEach(tooltip => {
        if (tooltip) { 
          tooltip.dispose();
        }
      });
      tooltipInstances.current = [];
    };
  }, []);

  useEffect(() => {
    tooltipInstances.current.forEach(tooltip => {
      if (tooltip) { 
        if (isCollapsed) {
          tooltip.enable();
        } else {
          tooltip.disable(); 
          tooltip.hide();    
        }
      }
    });
  }, [isCollapsed]);

useEffect(()=> {
           async function CarregarMerchants(){
                await GetMerchants();
           }
           if (isAuthenticated){
           CarregarMerchants();
          
           }
      
  },[isAuthenticated])

  return (<nav id="sidebar" className={`sidebar ${isCollapsed ? 'collapsed' : ''}`} ref={sidebarRef}>
    <div className="sidebar-header">
      <h3><i className="fas fa-s me-2"></i>S Logo</h3>
    </div>
      <div className="sidebar-header">
      <div className="sc-krITIZ fJsBbT">
       <select className= "form-select form-select-lg mb-3"
  value={selectedMerchant?.id /* || merchants[0]?.id || '' */}
  onChange={e => {
    const selected = merchants.find(m => m.id === e.target.value);
    setSelectedMerchant(selected);
  }}
>
  {merchants?.map(merchant => (
    <option key={merchant.id} value={merchant.id}>
      {merchant.name}
    </option>
  ))}
</select> 
        </div>
      </div>
    <ul className="nav flex-column">
      <li className="nav-item">
        <NavLink
          className={({ isActive }) => "nav-link" + (isActive ? " active" : "")}

          aria-current="page"
          to="/home"
          data-bs-toggle="tooltip" data-bs-placement="right" title="Início"
          end
        >
          <i className="fas fa-home"></i>
          <span>Início</span>
        </NavLink>
      </li>
      <li className="nav-item">
        <NavLink
          className={({ isActive }) => "nav-link" + (isActive ? " active" : "")}

          aria-current="page"
          to="/performace"
          data-bs-toggle="tooltip"
          data-bs-placement="right"
          title="Desempenho">
          <i className="fas fa-chart-line"></i>
          <span>Desempenho</span>
        </NavLink>
      </li>
      <li className="nav-item">
        <NavLink
          className={({ isActive }) => "nav-link" + (isActive ? " active" : "")}

          aria-current="page"
          to="/preventive"
          data-bs-toggle="tooltip"
          data-bs-placement="right"
          title="Ações Preventivas">
          <i className="fas fa-chart-line"></i>
          <span>Ações Preventivas</span>
        </NavLink>
      </li>
      <li className="nav-item">
        <NavLink
          className={({ isActive }) => "nav-link" + (isActive ? " active" : "")}

          aria-current="page"
          to="/orders"
          data-bs-toggle="tooltip"
          data-bs-placement="right"
          title="Pedidos">
          <i className="fas fa-shopping-cart"></i>
          <span>Pedidos</span>
        </NavLink>
      </li>
      <li className="nav-item">
        <NavLink
          className={({ isActive }) => "nav-link" + (isActive ? " active" : "")}
          aria-current="page"
          to="/reviews"
          data-bs-toggle="tooltip"
          data-bs-placement="right"
          title="Avaliações">
          <i className="fas fa-star"></i>
          <span>Avaliações</span>
        </NavLink>
      </li>
      <li className="nav-item">
        <NavLink
          className={({ isActive }) => "nav-link" + (isActive ? " active" : "")}
          aria-current="page"
          to="/crm"
          data-bs-toggle="tooltip"
          data-bs-placement="right"
          title="Seus Clientes">
          <i className="fas fa-user-friends"></i>
          <span>Seus Clientes</span>
        </NavLink>
      </li>
      <li className="nav-item">
       <NavLink
          className={({ isActive }) => "nav-link" + (isActive ? " active" : "")}
          aria-current="page"
          to="/menu/list"
          data-bs-toggle="tooltip"
          data-bs-placement="right"
          title="Cardápios">
          <i className="fas fa-comment"></i>
          <span>Cardápios</span>
        </NavLink>
      </li>
      <li className="nav-item">
        <NavLink
          className={({ isActive }) => "nav-link" + (isActive ? " active" : "")}
          aria-current="page"
          to="/merchant-delivery"
          data-bs-toggle="tooltip"
          data-bs-placement="right"
          title="Configuraçoes de Entrega">
          <i className="fas fa-bell"></i>
          <span>Configuraçoes de Entrega</span>
        </NavLink>
      </li>
      <li className="nav-item">
        <NavLink
          className={({ isActive }) => "nav-link" + (isActive ? " active" : "")}
          aria-current="page"
          to="/opening-hours"
          data-bs-toggle="tooltip"
          data-bs-placement="right"
          title="Horários">
          <i className="fas fa-cog"></i>
          <span>Horários</span>
        </NavLink>
      </li>
      <li className="nav-item">
       <NavLink
          className={({ isActive }) => "nav-link" + (isActive ? " active" : "")}
          aria-current="page"
          to="/scheduling"
          data-bs-toggle="tooltip"
          data-bs-placement="right"
          title="Horários">
          <i className="fas fa-star"></i>
          <span>Agendamento</span>
        </NavLink>
      </li>
      <li className="nav-item">
        <NavLink
          className={({ isActive }) => "nav-link" + (isActive ? " active" : "")}
          aria-current="page"
          to="/payment"
          data-bs-toggle="tooltip"
          data-bs-placement="right"
          title="Horários">
          <i className="fas fa-star"></i>
          <span>Forma de Pagamento</span>
        </NavLink>
      </li>
      <li className="nav-item dropdown ">
        <Link
          className="nav-link dropdown-toggle"
          onClick={() => setIsDropdownOpen(!isDropdownOpen)}
          data-bs-toggle="tooltip"
          data-bs-placement="right"
          title="Minha Loja">
        
          <i className="fa fa-industry" aria-hidden="true"></i>
          <span>Minha Loja</span>
       </Link>
        <ul className={`dropdown-menu dropdown-menu-end  ${isDropdownOpen ? "show" : ""}`} 
        aria-labelledby="navbarDropdown">
          <li>
            <Link className="dropdown-item"
            to="merchant/profile" href="#">Perfil</Link>
            </li>
          <li><Link to = "/profile/address" 
          className="dropdown-item">Configurações</Link>
          </li>

        </ul>
      </li>
      <li className="nav-item">
        <Link
          className="nav-link"
          aria-current="page"
          onClick={handleLogonOff}
          data-bs-toggle="tooltip"
          data-bs-placement="right"
          title="Sair">
          <i className="fas fa-sign-out"></i>
          <span>Sair</span>
        </Link>
      </li>
    </ul>
  </nav>
  )
}


const mapStateToProps = state => {
 
  return {
  isAuthenticated: state.Authenticacao.isAuthenticated,
  merchants : state.Merchants.merchants,
  selectedMerchant: state.Merchants.selectedMerchant,
  }
}

function mapDispatchToProps (dispatch) {
  return{
   // startLogout:() => dispatch(startLogout()),
    GetMerchants:() => dispatch(GetMerchants()),
    setSelectedMerchant:(merchants) => dispatch(setSelectedMerchant(merchants)),
  };
}

//const Sidebar = connect(mapStateToProps,mapDispatchToProps);

export default connect(mapStateToProps,mapDispatchToProps)(Sidebar) ;
//export default Sidebar;