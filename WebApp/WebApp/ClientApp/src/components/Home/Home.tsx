import * as React from 'react';
import { connect } from 'react-redux';
import './Home.css';

const Home = () => (
    <div id="videodiv">
      <video className='videoTag' autoPlay loop muted>
          <source src='https://file-examples-com.github.io/uploads/2017/04/file_example_MP4_1920_18MG.mp4' type='video/mp4' />
      </video>
    </div>
);

export default connect()(Home);
