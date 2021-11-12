import * as React from 'react';
import {Route, Switch} from "react-router";

import AllMeetupsPage from "./pages/AllMeetups";
import FavouritesPage from "./pages/Favourites";
import Layout from "./components/layout/Layout";

function App() {
   return(
     <Layout>
         <Switch>
             <Route path={'/'} exact={true} component={AllMeetupsPage} />
             <Route path={'/favourites'} component={FavouritesPage} />
         </Switch>
     </Layout>  
   );
}

export default App;
