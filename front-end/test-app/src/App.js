import React, { Component } from 'react';
import { bake_cookie, read_cookie, delete_cookie } from 'sfcookies';
import './App.css';
import LoginForm from './components/LoginForm';
import AgenciesForm from './components/AgenciesForm';

class App extends Component {
  constructor() {
    super(); 
    this.state = {     
      isLogin:read_cookie('isLogin') 
    };   
    this.handleClose = this.handleClose.bind(this);
    console.log('cookie head',this.state);
  } 

  handleClose(){
    console.log("Cerrar sesion");
    if(window.confirm("¿Desea cerrar sesión?")){
      delete_cookie('isLogin');
      window.location.reload(); 
    }
  }
  render() {
    const isLogin= this.state.isLogin;
    console.log('cookie render',this.state);

    let html;
    if(isLogin!='')
    {
        html=<AgenciesForm/>;
    }else{
      html=<LoginForm/> 

    }
    return (
      <div className="App">
        <input type="hidden" id="inputHidden" value="false"/>
        <nav className="navbar navbar-dark bg-dark">
          <a className="navbar-brand" href="/">
          Test App          
          </a>
          {
          (isLogin!='')?
          <span className="btn badge badge-pill badge-danger ml-2 btn-xl" onClick={this.handleClose}>
              X
          </span>:""
          }
        </nav>

        <div className="container">
            {html}
        </div>

      </div>
    );
  }
}

export default App;
