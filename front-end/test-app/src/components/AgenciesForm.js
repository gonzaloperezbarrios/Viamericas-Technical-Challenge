import React, { Component } from 'react';
import axios from 'axios';
import {DefaultConnection,MethodGetListAgency} from '../config/appsettings.json';
import { bake_cookie, read_cookie, delete_cookie } from 'sfcookies';
import { userInfo } from 'os';

class AgenciesForm extends Component 
{
  constructor () {
    super();
    this.state = {     
      urlService: DefaultConnection+MethodGetListAgency,
      status: "",
      id_token:read_cookie('id_token'),
      isLoading: false,
      error: false, 
      isLogin:read_cookie('isLogin'),
      todos:[]
    };
    this.LoadAgencies();
    this.NameSort=this.NameSort.bind(this);
    this.CitySort=this.CitySort.bind(this);
    this.StateSort=this.StateSort.bind(this);
  }
  
  LoadAgencies() 
  {
    console.log(this.state);
    const instance = axios.create({
      timeout: 1000,
      headers: {'Authorization': 'Bearer '+this.state.id_token}
    });
    instance.get(this.state.urlService)
    .then(result => {
      console.log(result);    
      this.setState({
        error:false,
        isLoading: false,
        todos:result.data
      });      
    })
    .catch(error => this.setState({
      error:true,
      isLoading: false
    }));     
  }

  NameSort(){
    const todosSort = this.state.todos.reverse(function (a, b)   {
      if (a.name > b.name) {
        return 1;
      }
      if (a.name < b.name) {
        return -1;
      }
      return 0;
    });
    this.setState({
      todos:todosSort
    });   
  }

  CitySort(){
    const todosSort = this.state.todos.reverse(function (a, b)   {
      if (a.city > b.city) {
        return 1;
      }
      if (a.city < b.city) {
        return -1;
      }
      return 0;
    });
    this.setState({
      todos:todosSort
    });   
  }

  StateSort(){
    const todosSort = this.state.todos.reverse(function (a, b)   {
      if (a.state > b.state) {
        return 1;
      }
      if (a.state < b.state) {
        return -1;
      }
      return 0;
    });
    this.setState({
      todos:todosSort
    });   
  }

  render() { 
    const todos = this.state.todos.map((todo, i) => {
      let color=(todo.status=='Open')?'text-primary':'text-danger';
      return (
        <tr className={color}>
          <td>{todo.name}</td>
          <td>{todo.city}</td>
          <td>{todo.state}</td>   
        </tr>
      )
    });
    return (
      <div className="col-sm-12 mx-auto">
      <div className="card card-signin my-5">
        <div className="card-body">
          <h5 className="card-title text-center">Lista Agencias</h5>
            <table className="table">
              <thead>
                <tr>   
                  <th 
                      scope="col" onClick={this.NameSort}>                   
                      <span className="btn btn-primary btn-sm">
                      <ion-icon name="arrow-dropdown"> </ion-icon>
                       Nombre
                      </span>                      
                  </th>
                  <th  
                      scope="col" onClick={this.CitySort}>                   
                      <span className="btn btn-primary btn-sm">
                      <ion-icon name="arrow-dropdown"> </ion-icon>
                       Ciudad
                      </span>  
                  </th>
                  <th 
                      scope="col" onClick={this.StateSort}>                   
                      <span className="btn btn-primary btn-sm">
                      <ion-icon name="arrow-dropdown"> </ion-icon>
                       Estado
                      </span>  
                  </th>
                </tr>
              </thead>
              <tbody>
                {todos}
              </tbody>
            </table>
          </div>
        </div>
      </div>
    );
  }
}

export default AgenciesForm;
