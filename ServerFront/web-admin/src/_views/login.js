import frontImg from "../assets/Images/frontImg.jpg";
import backImgs from "../assets/Images/backImg.jpg";
import { hasFormSubmit } from "@testing-library/user-event/dist/utils";
import React,{useState, useEffect} from "react";
import { useNavigate } from "react-router";
import { connect } from "react-redux";
import { login } from "../_actions/authentication.action";
import { history } from "../_helpers/history";
const Login =(props)=>{
   const{login,loading, error, isAuthenticated} = props;
   const navigate = useNavigate();

  const [formData, setFormData] = useState(
    {
        username:'',
        password:'Numsey#2022',
    });

 const handleChange = (e) => {
     const {name,value} = e.target;
     setFormData(prevState => ({
        ...prevState,
        [name]: value
     }));

    }
   const handleSubmit  = (e)=> {
        e.preventDefault();
        console.log('Dados enviados:', formData);
        login(formData);

    }
    if (isAuthenticated) {
         history.navigate("/home")
    }

    return(<><div className="pagelogin">
          
      <div className="container-box">
        <input type="checkbox" id="flip" />
        <div className='cover'>
          <div className="front">
            <img src={frontImg} alt="" />
            <div className="text">
              <span className="text-1">ddddddddddddd</span>
              <span className="text-2"> AAAAAAAAAAAAAAAAAAAAAA</span>
            </div>
          </div>
          <div className="back">
            <img src={backImgs} className="backImg" alt="" />
            <div className="text">
              <span className="text-1">Complete miles of journey <br /> with one step</span>
              <span className="text-2">Let's get started</span>
            </div>
          </div>

        </div>
        <div className="forms">
          <div className="form-content">
            <div className="login-form">
              <div className="title">Login</div>
              <form onSubmit={handleSubmit}>
                <div className="input-boxes">
                  <div className="input-box">
                    <i className="fas fa-envelope"></i>
                    <input type="text" 
                    placeholder="Enter your email" 
                    name="username" 
                    value={formData.username}
                     onChange={handleChange}
                     disabled={loading}
                    required />
                  </div>
                  <div className="input-box">
                    <i className="fas fa-lock"></i>
                    <input type="password" 
                    placeholder="Enter your password" 
                    name="password"
                    value={formData.password}
                     onChange={handleChange}
                     disabled={loading}
                    required />
                  </div>
                  <div className="text"><a href="#">Forgot password?</a></div>
                  <div className="button input-box">
                    <button type="submit" value="Sumbit" disabled ={loading}>
                      {loading ? (
                        <>
                      <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                           Loading...
                          </> 
                           ):('Entrar' 
                           )}
                      
                      </button>
                  </div>
                  <div className="text sign-up-text">Don't have an account? <label for="flip">Sigup now</label></div>
                </div>
              </form>
            </div>
            <div className="signup-form">
              <div className="title">Signup</div>
              <form action="#">
                <div className="input-boxes">
                  <div className="input-box">
                    <i className="fas fa-user"></i>
                    <input type="text" placeholder="Enter your name" required />
                  </div>
                  <div className="input-box">
                    <i className="fas fa-envelope"></i>
                    <input type="text" placeholder="Enter your email" required />
                  </div>
                  <div className="input-box">
                    <i className="fas fa-lock"></i>
                    <input type="password" placeholder="Enter your password" required />
                  </div>
                  <div className="button input-box">
                    <input type="submit" value="Sumbit" />
                  </div>
                  <div className="text sign-up-text">Already have an account? <label for="flip">Login now</label></div>
                </div>
              </form>
            </div>
          </div>
        </div>

      </div>
    </div></>)
}

const mapStateToProps = state => {
 console.log("State Login:", state); 
  return{
    //loading, error, isAuthenticated
      loading : state.Authenticacao.loading,
      error : state.Authenticacao.error,
      isAuthenticated: state.Authenticacao.isAuthenticated

  }
};

const mapDispatchToProps = (dispatch) => ({
 login:(formData) => dispatch(login(formData)),
  
});

const FromConectLogin = connect(mapStateToProps,mapDispatchToProps)(Login);

export {FromConectLogin as Login}