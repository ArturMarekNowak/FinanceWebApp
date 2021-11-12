import * as React from 'react';
import NewMeetupForm from "../components/meetups/NewMeetupForm";

function NewMeetupPage() {
    
    function addMeetupHandler(meetupData) {
        fetch('https://react-getting-started-90cb5-default-rtdb.europe-west1.firebasedatabase.app/meetups.json',
            {
                method: 'POST',
                body: JSON.stringify(meetupData),
                headers: {
                    'Content-type': 'application/json'
                }
            }
            );
    }
    
    return (
        <section>
            <h1>Add New Meetup</h1>
            <NewMeetupForm onAddMeetup={addMeetupHandler}/>
        </section>
    );
}

export default NewMeetupPage