import React from 'react';
// @material-ui/core components
import { createStyles, makeStyles, withStyles } from '@mui/styles';
import { Grid } from '@mui/material';

const style = createStyles({
  grid: {
    padding: '0 15px !important'
  }
});

function GridItem({ ...props }: any) {
  const { classes, children, ...rest } = props;
  return (
    <Grid item={true} {...rest} className={classes.grid}>
      {children}
    </Grid>
  );
}

export default withStyles(style)(GridItem);
