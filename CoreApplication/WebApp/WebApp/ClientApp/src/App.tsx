import * as React from 'react';
import {Route, Switch} from "react-router";

import AllCompaniesPage from "./pages/AllCompanies";
import FavouritesPage from "./pages/Favourites";
import Layout from "./components/layout/Layout";

function App() {
   return(
     <Layout>
         <Switch>
             <Route path={'/companies'} component={AllCompaniesPage} />
             <Route path={'/favourites'} component={FavouritesPage} />
         </Switch>
     </Layout>  
   );
}

export default App;