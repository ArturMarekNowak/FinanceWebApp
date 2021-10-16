import * as React from 'react';
import { connect } from 'react-redux';
import sample from '../../resources/FinanceWebAppHomePage.jpg';

const Home = () => (
    <div className="row">
        <div className="col-md-6">
            <section>
                <img src={sample} width={500} height={300} alt={"foo"}/>
            </section>
        </div>
        <div className="col-md-6 col-md-offset-2">
            <section>
                <p>
                    Our financial web application broadcasts informations about fastest growths on stock market to our users.
                </p>
            </section>
        </div>
    </div>
);

export default connect()(Home);
