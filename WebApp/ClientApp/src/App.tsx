import * as React from 'react';
import {Route, Switch} from "react-router";

import FavouritesPage from "./pages/Favourites";
import Layout from "./components/layout/Layout";
import AllCurrenciesPage from "./pages/AllCurrencies";

function App() {
   return(
     <Layout>
         <Switch>
             <Route path={'/currencies'} component={AllCurrenciesPage} />
             <Route path={'/favourites'} component={FavouritesPage} />
         </Switch>
     </Layout>  
   );
}

export default App;