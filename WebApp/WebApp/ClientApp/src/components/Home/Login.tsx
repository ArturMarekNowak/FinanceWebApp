import React, { useState, useEffect } from 'react';
import { Link, useLocation } from 'react-router-dom';
import { connect, useDispatch, useSelector } from 'react-redux';

const Login = () => (
  <div className="row">
    <div className="col-md-4">
      <section>
        <form id="account" method="post">
          <h3>Use a local account to log in.</h3>
          <hr />
          <div asp-validation-summary="All" className="text-danger"></div>
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
            <div className="checkbox">
              <label>Remember Me?</label>
              <input type="checkbox" />
            </div>
          </div>
          <div className="form-group">
            <button type="submit" className="btn btn-primary">Log in</button>
          </div>
          <div className="form-group">
            <p>
              <a id="forgot-password">Forgot your password?</a>
            </p>
            <p>
              <a>Register as a new user</a>
            </p>
            <p>
              <a id="resend-confirmation">Resend email confirmation</a>
            </p>
          </div>
        </form>
      </section>
    </div>
    <div className="col-md-6 col-md-offset-2">
      <section>
        <h4>Use another service to log in.</h4>
        <hr />
        <div>
          <p>
            There are no external authentication services configured. See <a href="https://go.microsoft.com/fwlink/?LinkID=532715"> this article</a>
            for details on setting up this ASP.NET application to support logging in via external services.
          </p>
        </div>

      </section>
    </div>
  </div>
);

export default connect()(Login);