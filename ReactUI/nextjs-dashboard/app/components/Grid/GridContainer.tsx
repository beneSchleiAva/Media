import React from 'react';
// @material-ui/core components
import { createStyles, makeStyles, withStyles } from '@mui/styles';
import { Grid } from '@mui/material';
const style = createStyles({
  grid: {
    margin: '0 -15px !important',
    width: 'unset'
  }
});

function GridContainer(props: any) {
  const { classes, children, ...rest } = props;
  return (
    <Grid container={true} {...rest} className={classes.grid}>
      {children}
    </Grid>
  );
}

export default withStyles(style)(GridContainer);
