import * as React from 'react';
import {Route, Switch} from "react-router";

import AllMeetupsPage from "./pages/AllMeetups";
import FavouritesPage from "./pages/Favourites";
import NewMeetupPage from "./pages/NewMeetup";
import MainNavigation from "./components/layout/MainNavigation";

function App() {
   return(
     <div>
         <MainNavigation />
         <Switch>
             <Route path={'/'} exact={true}>
                 <AllMeetupsPage />
             </Route>
             <Route path={'/new-meetup'}>
                 <NewMeetupPage />
             </Route>
             <Route path={'/favourites'}>
                 <FavouritesPage />
             </Route>
         </Switch>
     </div>  
   );
}

export default App;
