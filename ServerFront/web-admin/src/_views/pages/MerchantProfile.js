import React, { useEffect, useState, Suspense } from "react";
import { Profile } from "../../_components/Profile";
import Address from "../../_components/Address";
import { connect, useSelector, useDispatch } from 'react-redux';
import { loadingMerchant } from "../../_actions/merchantsProfile.action";
const MerchantProfile = (props) => {
  const { isAuthenticated, tabActive } = props;
  const [activeTab, setActiveTab] = useState(tabActive ?? 'overlay');
  const { selectedMerchant } = useSelector((state) => state.Merchants);

  const dispatch = useDispatch()

  useEffect(() => {
    dispatch(loadingMerchant(selectedMerchant?.id));
  }, [loadingMerchant, selectedMerchant?.id]);


  return (<div>
    <div className="content-wrapper" style={{ minHeight: '1518.4px' }}>
      {/* Content Header (Page header) */}
      <section className="content-header">
        <div className="container-fluid">
          <div className="row mb-2">
            <div className="col-sm-6">
              <h1>
                Minha Loja

              </h1>
            </div>
            <div className='fVDuuu'>
              <button class="fUWXSc" type="button" onClick={() => null}>
                <div class="eyVOuM" style={{ verticalAlign: 'middle' }}>
                  <svg viewBox="0 0 32 32" fill="none" width="36px" height="36px" color="#EB0033">
                    <path fill-rule="evenodd" clip-rule="evenodd" d="M19.6963 8.34873C20.1012 8.81404 20.1012 9.56845 19.6963 10.0338L14.5036 15.9998L19.6963 21.9658C20.1012 22.4311 20.1012 23.1855 19.6963 23.6508C19.2913 24.1161 18.6347 24.1161 18.2297 23.6508L12.3037 16.8423C11.8987 16.377 11.8987 15.6226 12.3037 15.1572L18.2297 8.34873C18.6347 7.88343 19.2913 7.88343 19.6963 8.34873Z" fill="currentColor">
                    </path>
                  </svg>

                </div>Voltar</button>
            </div>
          </div>
        </div>{/* /.container-fluid */}
      </section>
      {/* Main content */}
      <section className="content">
        <div className="container-fluid">

          <div className="row">
            <div className="col-md-12">
              <div className="card card-primary card-tabs">
                <div className="card-header p-0 pt-1">
                  <ul className="nav nav-tabs" role="tablist">
                    <li className="nav-item">
                      <button
                        className={`nav-link ${activeTab === 'overlay' ? 'active' : ''}`}
                        onClick={() => setActiveTab('overlay')}>
                        Loja
                      </button>
                    </li>
                    <li className="nav-item">
                      <button
                        className={`nav-link ${activeTab === 'overlay-dark' ? 'active' : ''}`}
                        onClick={() => setActiveTab('overlay-dark')}>
                        Endereço
                      </button>
                    </li>
                  </ul>
                </div>
                <div className="card-body">
                  <div className="tab-content">
                    {activeTab === 'overlay' && (

                      <div className="tab-pane fade show active">
                        <div className="overlay-wrapper">


                          <Profile />


                        </div></div>
                    )}
                    {activeTab === 'overlay-dark' && (
                      <div className="tab-pane fade show active">
                        <div className="overlay-wrapper">

                          <Address />
                        </div>
                      </div>
                    )}

                  </div>
                </div>
              </div>
            </div>
          </div>

        </div>
      </section>

    </div></div>)
}
/*
const mapStateToProps = state => {

  return {
  isAuthenticated: state.Authenticacao.isAuthenticated,
  }
}

function mapDispatchToProps (dispatch) {
  return{
  //  GetProfile:(MerchantId) => dispatch(GetProfile(MerchantId)),
  };
}

const ConnectMerchantProfile = connect(mapStateToProps,mapDispatchToProps)(MerchantProfile);
export {ConnectMerchantProfile as MerchantProfile}
*/
export { MerchantProfile }