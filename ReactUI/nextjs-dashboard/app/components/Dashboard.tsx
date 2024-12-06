import React from 'react';
// react plugin for creating charts
// @material-ui/core
import { withStyles } from '@mui/styles';
// core components
import GridItem from './Grid/GridItem';
import GridContainer from './Grid/GridContainer';
import Danger from './Typography/Danger';
import Card from './Card/Card';
import CardHeader from './Card/CardHeader';
import CardIcon from './Card/CardIcon';
import CardFooter from './Card/CardFooter';



import dashboardStyle from '../assets/jss/material-dashboard-react/views/dashboardStyle';
import { CardContent, Grid, Grid2, Icon, Typography } from '@mui/material';
import Warning from './Typography/Warning';

import DateRange from '@material-ui/icons/DateRange';
import Store from '@material-ui/icons/Store';
import Accessibility from '@material-ui/icons/Accessibility';
import LocalOffer from '@material-ui/icons/LocalOffer';

import Update from '@material-ui/icons/Update';

import BitCoinLogo from "./Bitcoin.png";
import { Fleur_De_Leah, Righteous } from 'next/font/google';

interface Props {
  classes: any;
}

interface State {
  value: number;
}

class Dashboard extends React.Component<Props, State> {
  constructor(props: Props) {
    super(props);
    this.state = {
      value: 0
    };
    this.handleChange = this.handleChange.bind(this);
    this.handleChangeIndex = this.handleChangeIndex.bind(this);
  }
  handleChange = (event: any, value: number) => {
    this.setState({ value });
  }

  handleChangeIndex = (index: number) => {
    this.setState({ value: index });
  }



  render() {
    const { classes } = this.props;
    return (
      <div>
        <GridContainer>
          <GridItem xs={12} sm={6} md={3}>
            <Card>
              <CardHeader color="warning" stats={true} icon={true}>
                <CardIcon color="warning">
                  <Grid2 container justifyContent={'space-around'}>
                    <Grid2 size={4} alignItems={'center'} justifyContent={'center'}>
                      <img alt="BC" src={"./Bitcoin.png"}></img>
                    </Grid2>
                    <Grid2 size={8} alignItems={'end'} display={'flex'}>
                      <Grid2 container size={12}>
                        <Grid2 size={12}>
                          <Grid2 container size={12}>
                            <Grid2 size={6}>
                              Aktueller Kurs
                            </Grid2>
                            <Grid2 size={4} display={'flex'} flexDirection={'row-reverse'} >
                              10 €
                            </Grid2>
                            
                          </Grid2>
                          <Grid2 container size={12}>
                            <Grid2 size={6}>
                              Entwicklung
                            </Grid2>
                            <Grid2 size={4} display={'flex'} flexDirection={'row-reverse'} >
                              10 €
                            </Grid2>
                          </Grid2>
                        </Grid2>
                      </Grid2>
                    </Grid2>
                  </Grid2>
                </CardIcon>
              </CardHeader>
              <CardContent>


              </CardContent>
            </Card>
          </GridItem>
          <GridItem xs={12} sm={6} md={3}>
            <Card>
              <CardHeader color="success" stats={true} icon={true}>
                <CardIcon color="success">
                  <Store />
                </CardIcon>
                <p className={classes.cardCategory}>Revenue</p>
                <h3 className={classes.cardTitle}>$34,245</h3>
              </CardHeader>
              <CardFooter stats={true}>
                <div className={classes.stats}>
                  <DateRange />
                  Last 24 Hours
                </div>
              </CardFooter>
            </Card>
          </GridItem>
          <GridItem xs={12} sm={6} md={3}>
            <Card>
              <CardHeader color="danger" stats={true} icon={true}>
                <CardIcon color="danger">
                  <Icon>info_outline</Icon>
                </CardIcon>
                <p className={classes.cardCategory}>Fixed Issues</p>
                <h3 className={classes.cardTitle}>75</h3>
              </CardHeader>
              <CardFooter stats={true}>
                <div className={classes.stats}>
                  <LocalOffer />
                  Tracked from Github
                </div>
              </CardFooter>
            </Card>
          </GridItem>
          <GridItem xs={12} sm={6} md={3}>
            <Card>
              <CardHeader color="info" stats={true} icon={true}>
                <CardIcon color="info">
                  <Accessibility />
                </CardIcon>
                <p className={classes.cardCategory}>Followers</p>
                <h3 className={classes.cardTitle}>+245</h3>
              </CardHeader>
              <CardFooter stats={true}>
                <div className={classes.stats}>
                  <Update />
                  Just Updated
                </div>
              </CardFooter>
            </Card>
          </GridItem>
        </GridContainer>
      </div >
    );
  }
}

// Dashboard.propTypes = {
//   classes: PropTypes.object.isRequired
// };

export default withStyles(dashboardStyle)(Dashboard);
