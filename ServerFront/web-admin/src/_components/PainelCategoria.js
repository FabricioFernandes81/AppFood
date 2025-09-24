import { Link, useNavigate } from "react-router";
import 'bootstrap/dist/css/bootstrap.min.css';
import '../assets/css/styleCardapio.css';
import 'bootstrap/dist/js/bootstrap.bundle.min';


const PainelCategoria = ({ children, category }) => {
    const navigate = useNavigate();


    const handleEditCategoria = (e) => {
            e.preventDefault();
            navigate(`../menu/category/${category.categoryId}?type=${category.type}`);
    }

   // console.log("Category= ", category)


    return (<>
        <div className='base-card'>
            <div className='base-cad-flex'>
                {category.name}
                <div className='dGHDvZ'>
                    <div className='bt'>
                        <button className="btn btn-outline-danger" onClick={() => null}>
                            <i class="fa fa-plus" aria-hidden="true"></i>
                            {category.type == "DEFAULT" ? ("Adicionar Item") : ("Adicionar Sabor")}
                        </button>
                    </div>
                    <div className='bt'>
                        <div className="dropdown">
                            <button
                                id="btnGroupDrop2"
                                type="button"
                                className="btn btn-outline-danger dropdown-toggle"
                                data-bs-toggle="dropdown"
                                aria-expanded="false"
                            >
                                <i className="fas fa-ellipsis-v"></i>
                            </button>
                            <ul className="dropdown-menu" aria-labelledby="btnGroupDrop2">
                                <li>
                                    <Link
                                        className="dropdown-item"
                                        onClick={(e) => {
                                            handleEditCategoria(e)
                                        }}
                                    >
                                        Editar item
                                    </Link>
                                </li>
                                <li>
                                    <a
                                        className="dropdown-item"
                                        href="#"
                                        onClick={(e) => {
                                            e.preventDefault();
                                            console.log("Remover item clicado");
                                            // Aqui você pode chamar uma função para remover
                                        }}
                                    >
                                        Remover item
                                    </a>
                                </li>
                            </ul>
                        </div>


                    </div>
                </div>
              
            </div>
        </div>
        {children}
    </>)
}

export { PainelCategoria }