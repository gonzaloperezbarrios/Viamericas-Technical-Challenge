import React, { Component } from 'react';
import axios from 'axios';
import {DefaultConnection,MethodLogin} from '../config/appsettings.json';
import { bake_cookie, read_cookie, delete_cookie } from 'sfcookies';

class LoginForm extends Component 
{
  constructor () {
    super();
    this.state = {     
      urlService: DefaultConnection+MethodLogin,
      status: "",
      id_token:"",
      isLoading: false,
      error: false, 
      isLogin:read_cookie('isLogin')   
    };
    this.handleSubmit = this.handleSubmit.bind(this);
  }
  
  handleSubmit(e) 
  {
    e.preventDefault();
    var user=document.getElementById('inputUser').value;
    var password=document.getElementById('inputPassword').value;
    if(user!='' && password !=''){
      this.setState({ isLoading: true, error:false });
      axios.post(this.state.urlService,{
          username: user, 
          password: password
        })
        .then(result => {
          console.log(result);
          this.setState({
            status: result.data.status,
            id_token: result.data.id_token,
            isLoading: false,
            isLogin: (result.data.status!=null)?true:false
          });
          if(result.data.status==null){
            alert("Usuario o contraseña invalida");
          }else{
            bake_cookie('isLogin','true');
            bake_cookie('id_token',result.data.id_token);
            window.location.reload();
          }
        })
        .catch(error => this.setState({
          error:true,
          isLoading: false
        }));     
    }   
  }

  render() {
    const isLogin=this.state.isLogin;
    let html;
    if(isLogin!='')
    {
        html="Bienvenido";
    }else{
      html=<div className="row">
      <div className="col-sm-9 col-md-7 col-lg-5 mx-auto">
        <div className="card card-signin my-5">
          <div className="card-body">
            <h5 className="card-title text-center">Test App</h5>
            <form className="form-signin" onSubmit={this.handleSubmit}>
              <div className="form-label-group">
                <input type="text" name="user" id="inputUser" className="form-control" placeholder="Usuario" required autoFocus/>
                <label htmlFor="inputUser">Usuario</label>
              </div>
              <div className="form-label-group">
                <input type="password" type="password" id="inputPassword" className="form-control" placeholder="Contraseña" required/>
                <label htmlFor="inputPassword">Contraseña</label>
              </div>               
              <button className="btn btn-lg btn-primary btn-block text-uppercase" type="submit">Ingresar</button>
          </form>
          </div>
        </div>
      </div>
    </div>

    }
    return (
      html
    );
  }
}

export default LoginForm;
