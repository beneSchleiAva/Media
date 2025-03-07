import React from 'react';
// @material-ui/core components
import { createStyles, makeStyles, withStyles } from '@mui/styles';
// core components
import typographyStyle from '../../assets/jss/material-dashboard-react/components/typographyStyle';

function Danger({ ...props }: any) {
  const { classes, children } = props;
  return (
    <div className={classes.defaultFontStyle + ' ' + classes.dangerText}>
      {children}
    </div>
  );
}

export default withStyles(typographyStyle)(Danger);