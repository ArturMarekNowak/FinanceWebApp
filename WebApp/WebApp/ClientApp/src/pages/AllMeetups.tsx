import * as React from 'react';
import MeetupList from "../components/meetups/MeetupList";
import { useState, useEffect } from "react";

function AllMeetupsPage() {
    
    const [ isLoading, setIsLoading ] = useState(true);
    const [ loadedMeetups, setLoadedMeetups ] = useState([]);
    
    useEffect(() => {
        setIsLoading(true);
        fetch('https://localhost:5001/api/Companies')
            .then(response => {
                return response.json();
            })
            .then(data => {
                
            const meetups = [];

                for (const key in data["value"]) {
                    const meetup = {
                        id: key, 
                        CompanyId: data["value"][key]["CompanyId"],
                        Acronym: data["value"][key]["Acronym"],
                        FullName: data["value"][key]["FullName"]
                    };
                    meetups.push(meetup)
                }
                
            setIsLoading(false);
            setLoadedMeetups(meetups);
        });
    }, []);
    
    if(isLoading)
    {
        return (
          <section>
              <p>Loading...</p>
          </section>  
        );
    }
    
    return (
        <section>
            <MeetupList meetups={loadedMeetups} />
        </section>
    );
}

export default AllMeetupsPage