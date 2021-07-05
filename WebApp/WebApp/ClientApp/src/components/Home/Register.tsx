import React, { useState, useEffect } from 'react';
import { Link, useLocation } from 'react-router-dom';
import { connect, useDispatch, useSelector } from 'react-redux';

const Login = () => (
  <div className="row">
    <div className="col-md-4">
      <h2>Create a new account.</h2>
      <hr />
      <div className="form-group">
        <label>Email</label>
        <input className="form-control" />
        <span className="text-danger"></span>
      </div>
      <div className="form-group">
        <label>Password</label>
        <input className="form-control" />
        <span className="text-danger"></span>
      </div>
      <div className="form-group">
        <label>Confirm password</label>
        <input className="form-control" />
        <span className="text-danger"></span>
      </div>
      <button type="submit" className="btn btn-primary">Register</button>
    </div>
    <div className="col-md-6 col-md-offset-2">
      <section>
        <h4>Use another service to register.</h4>
        <div>
          <p>
            There are no external authentication services configured. See <a href="https://go.microsoft.com/fwlink/?LinkID=532715">this article</a>
            for details on setting up this ASP.NET application to support logging in via external services.
          </p>
        </div>
      </section>
    </div>
  </div>
);

export default connect()(Login);