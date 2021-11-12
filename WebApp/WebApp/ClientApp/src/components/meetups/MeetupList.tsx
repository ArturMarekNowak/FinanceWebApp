import * as React from 'react';
import MeetupItem from './MeetupItem';
import classes from './MeetupList.module.css';

function MeetupList(props) {
    
    console.log(props)
    return (
        <ul className={classes.list}>
            {props.meetups.map((meetup) => (
                <MeetupItem
                    key={meetup.id}
                    id={meetup.id}
                    CompanyId={meetup.CompanyId}
                    Acronym={meetup.Acronym}
                    FullName={meetup.FullName}
                />
            ))}
        </ul>
    );
}

export default MeetupList;