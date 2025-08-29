import { useSelector, useDispatch } from "react-redux";
import React, { useState, useEffect } from "react";
import { useNavigate, useSearchParams, useParams } from "react-router";
import '../../assets/css/styleCategoria.css'
import { selectCatalog, deselectCatalog } from '../../_actions/catalogoSelecionado.actions';
import { Link } from "react-router-dom";

import { loadingCategoryId,UpdateFormField,submitCategory,submitEditCategory } from "../../_actions/CategoryForm.action";
const TypeCategoria = () => {
  const [isEditMode, setIsEditMode] = useState(false);
  const [searchParams] = useSearchParams();
  const navigate = useNavigate();
  const { id } = useParams();
  const type = searchParams.get("type");
  const { selectedMerchant } = useSelector((state) => state.Merchants);
  const { categoryform,loading } = useSelector((state) => state.FormCategoria);
  const { catalogs } = useSelector((state) => state.MenuList);
  const { selectedCatalogs } = useSelector((state) => state.CatalogoSelecionado);
  
  const dispatch = useDispatch();
  
  const handleChange = (e) => {
    const { name, value } = e.target;
    dispatch(UpdateFormField(name, value));
  };
   
   
   useEffect(() => {
  if (!selectedCatalogs || selectedCatalogs.length === 0) {
    navigate('../../menu/catalogs');
  }
}, [selectedCatalogs, navigate]); 
      console.log("CAtalogo Selecionado:",selectedCatalogs)

  useEffect(() => {
    if (id) {
      setIsEditMode(true);
       const fetCategory = async () => {
          try {
            dispatch(loadingCategoryId(selectedMerchant?.id, id))
                 
         } catch (error) {
            console.log("Erro ao carregar Categoria", error);
      }
    };
      fetCategory();

    }
  }, [dispatch, selectedMerchant?.id, id])

  const handleSubimit = (e) => {
    e.preventDefault();
   
    try {
      if(isEditMode){
        const DadosCategory ={
             name:categoryform.name,
          }
       dispatch(submitEditCategory(DadosCategory));
      }else{
       const DadosCategory ={
        name : categoryform.name,
        template: type,
        catalogs : selectedCatalogs
      }
        dispatch(submitCategory(selectedMerchant?.id,DadosCategory))
      }
      navigate('/category');
    } catch (error) {
      
    }
  }


  function renderSwitch(type) {
    switch (type) {
      case "DEFAULT":
        return (<div><div className="menu-management-container">
          <header className="gxujlE">
            <div className='fVDuuu'>
              <button class="fUWXSc" type="button" onClick={null}>
                <div class="eyVOuM" style={{ verticalAlign: 'middle' }}>
                  <svg viewBox="0 0 32 32" fill="none" width="36px" height="36px" color="#EB0033">
                    <path fill-rule="evenodd" clip-rule="evenodd" d="M19.6963 8.34873C20.1012 8.81404 20.1012 9.56845 19.6963 10.0338L14.5036 15.9998L19.6963 21.9658C20.1012 22.4311 20.1012 23.1855 19.6963 23.6508C19.2913 24.1161 18.6347 24.1161 18.2297 23.6508L12.3037 16.8423C11.8987 16.377 11.8987 15.6226 12.3037 15.1572L18.2297 8.34873C18.6347 7.88343 19.2913 7.88343 19.6963 8.34873Z" fill="currentColor">
                    </path>
                  </svg>
                </div>Voltar</button>
            </div>
            <h1 class="ePciIf"> {isEditMode ? 'Editar categoria' : 'Nova categoria'}</h1>
          </header>
          <div>
            <p class="dgVITK">Preencha as informações da nova categoria.</p>
          </div>
          <div className="Ewpqy">
            <div class="VKNTj">
              <div class="dGHDvZ">
                <img src="data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iNDEiIGhlaWdodD0iMzQiIHZpZXdCb3g9IjAgMCA0MSAzNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPGcgY2xpcC1wYXRoPSJ1cmwoI2NsaXAwKSI+CjxwYXRoIGQ9Ik0zNC4wMTk1IDE2Ljg3OTlDMzQuMDE5NSAxMS45MTk5IDMxLjQzOTUgNy41NTk4OCAyNy41Mzk1IDUuMDU5ODhDMjUuMzU5NSAzLjY3OTg4IDIyLjc3OTUgMi44Nzk4OCAyMC4wMTk1IDIuODc5ODhDMTcuNzc5NSAyLjg3OTg4IDE1LjYzOTUgMy40MTk4OCAxMy43NTk1IDQuMzU5ODhDOS4xNTk1MyA2LjY1OTg4IDYuMDE5NTMgMTEuMzk5OSA2LjAxOTUzIDE2Ljg3OTlDNi4wMTk1MyAyMC43MTk5IDcuNTU5NTMgMjQuMTk5OSAxMC4wNzk1IDI2LjczOTlDMTIuNjE5NSAyOS4yOTk5IDE2LjEzOTUgMzAuODc5OSAyMC4wMTk1IDMwLjg3OTlDMjIuNDM5NSAzMC44Nzk5IDI0LjY5OTUgMzAuMjU5OSAyNi42OTk1IDI5LjE5OTlDMzEuMDM5NSAyNi44MTk5IDM0LjAxOTUgMjIuMTk5OSAzNC4wMTk1IDE2Ljg3OTlaIiBmaWxsPSIjRkNFQkVBIi8+CjxwYXRoIGQ9Ik0yNC4wMzkxIDIyLjQyMDJMMjYuOTk5MSAyNS4zODAyTDM3LjI5OTEgMTUuMDgwMkMzOC45MzkxIDEzLjQ0MDIgMzguOTM5MSAxMC44MDAyIDM3LjI5OTEgOS4xNjAxNkwyNC4wMzkxIDIyLjQyMDJaIiBzdHJva2U9IiNFQTFEMkMiIHN0cm9rZS13aWR0aD0iMyIgc3Ryb2tlLW1pdGVybGltaXQ9IjEwIiBzdHJva2UtbGluZWNhcD0icm91bmQiIHN0cm9rZS1saW5lam9pbj0icm91bmQiLz4KPHBhdGggZD0iTTIzLjk3OTcgMjIuNDhMMTQuMTc5NyAzMi4yOCIgc3Ryb2tlPSIjRUExRDJDIiBzdHJva2Utd2lkdGg9IjMiIHN0cm9rZS1taXRlcmxpbWl0PSIxMCIgc3Ryb2tlLWxpbmVjYXA9InJvdW5kIiBzdHJva2UtbGluZWpvaW49InJvdW5kIi8+CjxwYXRoIGQ9Ik0xNC42MiAxNC45OEwxLjUgMjguMSIgc3Ryb2tlPSIjRUExRDJDIiBzdHJva2Utd2lkdGg9IjMiIHN0cm9rZS1taXRlcmxpbWl0PSIxMCIgc3Ryb2tlLWxpbmVjYXA9InJvdW5kIiBzdHJva2UtbGluZWpvaW49InJvdW5kIi8+CjxwYXRoIGQ9Ik0yNC41NjAyIDUuMDQwMDRMMTguNjYwMiAxMC45NiIgc3Ryb2tlPSIjRUExRDJDIiBzdHJva2Utd2lkdGg9IjMiIHN0cm9rZS1taXRlcmxpbWl0PSIxMCIgc3Ryb2tlLWxpbmVjYXA9InJvdW5kIiBzdHJva2UtbGluZWpvaW49InJvdW5kIi8+CjxwYXRoIGQ9Ik0yMS4wMjA0IDEuNUwxNC42MjA0IDcuODhDMTIuNjYwNCA5Ljg0IDEyLjY2MDQgMTMuMDIgMTQuNjIwNCAxNC45OEMxNi41ODA0IDE2Ljk0IDE5Ljc2MDQgMTYuOTQgMjEuNzIwNCAxNC45OEwyOC4xMDA0IDguNiIgc3Ryb2tlPSIjRUExRDJDIiBzdHJva2Utd2lkdGg9IjMiIHN0cm9rZS1taXRlcmxpbWl0PSIxMCIgc3Ryb2tlLWxpbmVjYXA9InJvdW5kIiBzdHJva2UtbGluZWpvaW49InJvdW5kIi8+CjxwYXRoIGQ9Ik0xNS4wOTk2IDcuMzk5OUwyMi4xOTk2IDE0LjQ5OTkiIHN0cm9rZT0iI0VBMUQyQyIgc3Ryb2tlLXdpZHRoPSIzIiBzdHJva2UtbWl0ZXJsaW1pdD0iMTAiIHN0cm9rZS1saW5lY2FwPSJyb3VuZCIgc3Ryb2tlLWxpbmVqb2luPSJyb3VuZCIvPgo8L2c+CjxkZWZzPgo8Y2xpcFBhdGggaWQ9ImNsaXAwIj4KPHJlY3Qgd2lkdGg9IjQwLjAyIiBoZWlnaHQ9IjMzLjc4IiBmaWxsPSJ3aGl0ZSIvPgo8L2NsaXBQYXRoPgo8L2RlZnM+Cjwvc3ZnPgo=" alt="category-type-card" width="24" height="24" />
                <p class="jAqlyU">Itens principais</p></div>
                {isEditMode || (
              <button class="BaseButton-sc-odyat6-0 fUWXSc" type="button" onClick={null}>Alterar</button>
              )} 
              </div>
               
          </div>
          <form onSubmit={handleSubimit}>
            <div className="mb-4">
              <label htmlFor="nome" className="form-label">Nome</label>
              <div className="position-relative">
                <input
                  type="text"
                  className="form-control"
                  id="name"
                  name="name"
                  onChange={handleChange}
                  value={categoryform?.name || ''}
                  maxLength={40}
                  disabled={loading}
                  placeholder="Digite o nome da categoria"
                />
                <small className="position-absolute end-0 bottom-0 text-secondary p-2">
                   {categoryform.name.length}/40
                </small>
              </div>
            </div>

            {/* Botões de ação */}
            <div className="d-flex justify-content-end gap-2">
              <button
                type="button"
                className="btn btn-link text-danger"
                style={{ textDecoration: 'none' }}
              >
                Cancelar
              </button>
              <button
                type="submit"
                className="btn btn-light"
              // disabled={!nome.trim()}
              >
                Criar categoria
              </button>
            </div>
          </form>

        </div></div>);
      case "PIZZA":
        return (<div>SELECT PIZZA</div>);

      default:
        return (<><div className="menu-management-container">
          <header className="gxujlE">
            <div className='fVDuuu'>
              <button class="fUWXSc" type="button" onClick={() => null()}>
                <div class="eyVOuM" style={{ verticalAlign: 'middle' }}>
                  <svg viewBox="0 0 32 32" fill="none" width="36px" height="36px" color="#EB0033">
                    <path fill-rule="evenodd" clip-rule="evenodd" d="M19.6963 8.34873C20.1012 8.81404 20.1012 9.56845 19.6963 10.0338L14.5036 15.9998L19.6963 21.9658C20.1012 22.4311 20.1012 23.1855 19.6963 23.6508C19.2913 24.1161 18.6347 24.1161 18.2297 23.6508L12.3037 16.8423C11.8987 16.377 11.8987 15.6226 12.3037 15.1572L18.2297 8.34873C18.6347 7.88343 19.2913 7.88343 19.6963 8.34873Z" fill="currentColor">
                    </path>
                  </svg>
                </div>Voltar</button>
            </div>
            <h1 class="ePciIf">Nova categoria</h1>
          </header>
          <div>
            <p class="dgVITK">Selecione o modelo de categoria para dividir o seu cardápio</p>
          </div>
          <div data-testid="menu-category-page" class="jWynGo">
            <Link class="gZnMZL claEbR" to="../menu/category?type=DEFAULT">
              <div class="cNzPbm iNdQGU">
                <div>
                  <img src="data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iNDEiIGhlaWdodD0iMzQiIHZpZXdCb3g9IjAgMCA0MSAzNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPGcgY2xpcC1wYXRoPSJ1cmwoI2NsaXAwKSI+CjxwYXRoIGQ9Ik0zNC4wMTk1IDE2Ljg3OTlDMzQuMDE5NSAxMS45MTk5IDMxLjQzOTUgNy41NTk4OCAyNy41Mzk1IDUuMDU5ODhDMjUuMzU5NSAzLjY3OTg4IDIyLjc3OTUgMi44Nzk4OCAyMC4wMTk1IDIuODc5ODhDMTcuNzc5NSAyLjg3OTg4IDE1LjYzOTUgMy40MTk4OCAxMy43NTk1IDQuMzU5ODhDOS4xNTk1MyA2LjY1OTg4IDYuMDE5NTMgMTEuMzk5OSA2LjAxOTUzIDE2Ljg3OTlDNi4wMTk1MyAyMC43MTk5IDcuNTU5NTMgMjQuMTk5OSAxMC4wNzk1IDI2LjczOTlDMTIuNjE5NSAyOS4yOTk5IDE2LjEzOTUgMzAuODc5OSAyMC4wMTk1IDMwLjg3OTlDMjIuNDM5NSAzMC44Nzk5IDI0LjY5OTUgMzAuMjU5OSAyNi42OTk1IDI5LjE5OTlDMzEuMDM5NSAyNi44MTk5IDM0LjAxOTUgMjIuMTk5OSAzNC4wMTk1IDE2Ljg3OTlaIiBmaWxsPSIjRkNFQkVBIi8+CjxwYXRoIGQ9Ik0yNC4wMzkxIDIyLjQyMDJMMjYuOTk5MSAyNS4zODAyTDM3LjI5OTEgMTUuMDgwMkMzOC45MzkxIDEzLjQ0MDIgMzguOTM5MSAxMC44MDAyIDM3LjI5OTEgOS4xNjAxNkwyNC4wMzkxIDIyLjQyMDJaIiBzdHJva2U9IiNFQTFEMkMiIHN0cm9rZS13aWR0aD0iMyIgc3Ryb2tlLW1pdGVybGltaXQ9IjEwIiBzdHJva2UtbGluZWNhcD0icm91bmQiIHN0cm9rZS1saW5lam9pbj0icm91bmQiLz4KPHBhdGggZD0iTTIzLjk3OTcgMjIuNDhMMTQuMTc5NyAzMi4yOCIgc3Ryb2tlPSIjRUExRDJDIiBzdHJva2Utd2lkdGg9IjMiIHN0cm9rZS1taXRlcmxpbWl0PSIxMCIgc3Ryb2tlLWxpbmVjYXA9InJvdW5kIiBzdHJva2UtbGluZWpvaW49InJvdW5kIi8+CjxwYXRoIGQ9Ik0xNC42MiAxNC45OEwxLjUgMjguMSIgc3Ryb2tlPSIjRUExRDJDIiBzdHJva2Utd2lkdGg9IjMiIHN0cm9rZS1taXRlcmxpbWl0PSIxMCIgc3Ryb2tlLWxpbmVjYXA9InJvdW5kIiBzdHJva2UtbGluZWpvaW49InJvdW5kIi8+CjxwYXRoIGQ9Ik0yNC41NjAyIDUuMDQwMDRMMTguNjYwMiAxMC45NiIgc3Ryb2tlPSIjRUExRDJDIiBzdHJva2Utd2lkdGg9IjMiIHN0cm9rZS1taXRlcmxpbWl0PSIxMCIgc3Ryb2tlLWxpbmVjYXA9InJvdW5kIiBzdHJva2UtbGluZWpvaW49InJvdW5kIi8+CjxwYXRoIGQ9Ik0yMS4wMjA0IDEuNUwxNC42MjA0IDcuODhDMTIuNjYwNCA5Ljg0IDEyLjY2MDQgMTMuMDIgMTQuNjIwNCAxNC45OEMxNi41ODA0IDE2Ljk0IDE5Ljc2MDQgMTYuOTQgMjEuNzIwNCAxNC45OEwyOC4xMDA0IDguNiIgc3Ryb2tlPSIjRUExRDJDIiBzdHJva2Utd2lkdGg9IjMiIHN0cm9rZS1taXRlcmxpbWl0PSIxMCIgc3Ryb2tlLWxpbmVjYXA9InJvdW5kIiBzdHJva2UtbGluZWpvaW49InJvdW5kIi8+CjxwYXRoIGQ9Ik0xNS4wOTk2IDcuMzk5OUwyMi4xOTk2IDE0LjQ5OTkiIHN0cm9rZT0iI0VBMUQyQyIgc3Ryb2tlLXdpZHRoPSIzIiBzdHJva2UtbWl0ZXJsaW1pdD0iMTAiIHN0cm9rZS1saW5lY2FwPSJyb3VuZCIgc3Ryb2tlLWxpbmVqb2luPSJyb3VuZCIvPgo8L2c+CjxkZWZzPgo8Y2xpcFBhdGggaWQ9ImNsaXAwIj4KPHJlY3Qgd2lkdGg9IjQwLjAyIiBoZWlnaHQ9IjMzLjc4IiBmaWxsPSJ3aGl0ZSIvPgo8L2NsaXBQYXRoPgo8L2RlZnM+Cjwvc3ZnPgo=" alt="DEFAULT" width="100" height="100" />
                  <p class="izNmos">Itens principais</p>
                  <p class="bnrFKF">Defina nome e descrição pra categorias de marmitas, lanches, sobremesas, etc.</p>
                </div>
              </div>
            </Link>
            <Link class="gZnMZL" to="../menu/category?type=PIZZA">
              <div class="cNzPbm iNdQGU">
                <div>
                  <img src="data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iNDAiIGhlaWdodD0iNDEiIHZpZXdCb3g9IjAgMCA0MCA0MSIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPHBhdGggZmlsbC1ydWxlPSJldmVub2RkIiBjbGlwLXJ1bGU9ImV2ZW5vZGQiIGQ9Ik0xMy45ODI2IDMuMzc0NDlDMTQuNjc4MSAxLjU4ODE2IDE2LjY3NDUgMC41NTQ3NCAxOC41NjY2IDEuMTczOTZMMTguNTg3IDEuMTgwNjJDMjguNTI0MSA0LjU5MDYxIDM2LjMyOTEgMTIuMzk0NiAzOS43MTk0IDIyLjMxNDRMMzkuNzI1OCAyMi4zMzNDNDAuMzQ0OSAyNC4yMjQ3IDM5LjMxMTggMjYuMjIwOSAzNy41MjYgMjYuOTE2N0wzNy41MjM3IDI2LjkxNzZMMjkuMDY4IDMwLjIzNTlDMjguMjk2OCAzMC41Mzg1IDI3LjQyNjQgMzAuMTU4NyAyNy4xMjM3IDI5LjM4NzVDMjYuODIxMSAyOC42MTY0IDI3LjIwMDkgMjcuNzQ1OSAyNy45NzIxIDI3LjQ0MzJMMzEuNDQyOSAyNi4wODEyQzI4LjMwNTMgMTguNTY1NiAyMi4zMzM0IDEyLjU3OTggMTQuODI0NSA5LjQ1NjgxTDEzLjc0OTYgMTIuMjA0NEMxNC43MTEzIDEyLjM1OSAxNS42NDAxIDEyLjgwNiAxNi4zODYgMTMuNTY0OEMxOC4yNjY1IDE1LjQ1MSAxOC4yNjQ3IDE4LjQ5NjggMTYuMzgwNyAyMC4zODA4QzE0LjcyODkgMjIuMDMyNiAxMi4xODM5IDIyLjIzNzUgMTAuMzEwNSAyMC45OTU1TDQuMTQ2NzggMzYuNzUxM0w4LjczOTg2IDM0Ljk1MTNDNy43MzE4MSAzMy4xMTg5IDguMDA0OTggMzAuNzczNyA5LjU1OTM2IDI5LjIxOTRDMTEuNDQ1MSAyNy4zMzM2IDE0LjQ5NDkgMjcuMzMzNiAxNi4zODA3IDI5LjIxOTRDMTcuMDI3NCAyOS44NjYxIDE3LjQ0NDcgMzAuNjQ0MiAxNy42NDQ0IDMxLjQ2MTZMMjAuMTkyNyAzMC40NjNDMjAuOTY0IDMwLjE2MDcgMjEuODM0NCAzMC41NDA5IDIyLjEzNjYgMzEuMzEyMkMyMi40Mzg5IDMyLjA4MzYgMjIuMDU4NyAzMi45NTM5IDIxLjI4NzQgMzMuMjU2MUwyLjA0NzM1IDQwLjc5NjFDMS40OTIzOSA0MS4wMTM2IDAuODYxMzA0IDQwLjg4MTkgMC40Mzk2OTkgNDAuNDYwNUMwLjAxODA5MzggNDAuMDM5MiAtMC4xMTQwMjUgMzkuNDA4MiAwLjEwMzEzMyAzOC44NTMxTDguNDMyNSAxNy41NjE2QzguNDM5MjUgMTcuNTQzMyA4LjQ0NjM0IDE3LjUyNTIgOC40NTM3OCAxNy41MDcyTDEzLjk4MjYgMy4zNzQ0OVpNMTQuNzgzNyAzMi41ODI3TDExLjU5OCAzMy44MzEyQzEwLjk2NzYgMzMuMTEzNCAxMC45OTUyIDMyLjAyNjIgMTEuNjgwNyAzMS4zNDA3QzEyLjM5NDkgMzAuNjI2NSAxMy41NDUxIDMwLjYyNjUgMTQuMjU5NCAzMS4zNDA3QzE0LjU5NzggMzEuNjc5MSAxNC43NzUgMzIuMTIzMSAxNC43ODM3IDMyLjU4MjdaTTExLjQ3NiAxOC4wMTYzQzExLjUzNTQgMTguMTAxMSAxMS42MDM1IDE4LjE4MjIgMTEuNjgwNyAxOC4yNTk1QzEyLjM5NDkgMTguOTczNyAxMy41NDUyIDE4Ljk3MzcgMTQuMjU5NCAxOC4yNTk1QzE0Ljk3MzYgMTcuNTQ1MiAxNC45NzM2IDE2LjM5NSAxNC4yNTk0IDE1LjY4MDhMMTQuMjQ4NyAxNS42NzAxTDE0LjI0ODcgMTUuNjdDMTMuODEwNSAxNS4yMjI4IDEzLjE3NjcgMTUuMDU2MyAxMi41ODQ2IDE1LjE4MjVMMTEuNDc2IDE4LjAxNjNaTTM2LjQzMjEgMjQuMTIzMkwzNC4yMzYxIDI0Ljk4NUMzMC43OTQyIDE2LjY5NjEgMjQuMjA4OSAxMC4wOTIzIDE1LjkxNzcgNi42NjI0TDE2Ljc3ODEgNC40NjMyM0MxNi45MjE5IDQuMDkzMjcgMTcuMzE5OSAzLjkyNzA5IDE3LjYyNjQgNC4wMjI4OEMyNi42NzkgNy4xMzM5IDMzLjc4NjIgMTQuMjQyNiAzNi44NzY1IDIzLjI3MjdDMzYuOTcyNyAyMy41NzkzIDM2LjgwNjUgMjMuOTc3NiAzNi40MzY0IDI0LjEyMTVMMzYuNDMyMSAyNC4xMjMyWk0yNS4xNDU1IDIzLjYxNTlDMjUuNjA3MiAyMi45MjggMjUuNDIzNyAyMS45OTYxIDI0LjczNTggMjEuNTM0NUMyNC4wNDc5IDIxLjA3MjkgMjMuMTE2MSAyMS4yNTYzIDIyLjY1NDUgMjEuOTQ0MkMyMi4wOTEzIDIyLjc4MzQgMjAuOTQwOCAyMy4wMDgxIDIwLjExNTggMjIuNDU0NUMxOS40Mjc5IDIxLjk5MjkgMTguNDk2MSAyMi4xNzYzIDE4LjAzNDUgMjIuODY0MkMxNy41NzI4IDIzLjU1MjEgMTcuNzU2MyAyNC40ODQgMTguNDQ0MiAyNC45NDU2QzIwLjY1OTIgMjYuNDMyIDIzLjY2ODcgMjUuODE2NiAyNS4xNDU1IDIzLjYxNTlaIiBmaWxsPSIjRUExRDJDIi8+Cjwvc3ZnPgo=" alt="PIZZA" width="100" height="100" />
                  <p class="BaseText-sc-1a1327l-0 izNmos">Pizza</p>
                  <p class="BaseText-sc-1a1327l-0 bnrFKF">Defina o tamanho, tipos de massa, bordas e sabores</p>
                </div>
              </div>
            </Link>
          </div>

        </div></>)
    }
  }



  return (<>{renderSwitch(type)}</>)
}

export { TypeCategoria }