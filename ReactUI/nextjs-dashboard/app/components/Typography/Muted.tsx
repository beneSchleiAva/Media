import React from 'react';
// import PropTypes from "prop-types";
import { createStyles, makeStyles, withStyles } from '@mui/styles';
// core components
import typographyStyle from '../../assets/jss/material-dashboard-react/components/typographyStyle';

function Muted({ ...props }: any) {
  const { classes, children } = props;
  return (
    <div className={classes.defaultFontStyle + ' ' + classes.mutedText}>
      {children}
    </div>
  );
}

// Muted.propTypes = {
//   classes: PropTypes.object.isRequired
// };

export default withStyles(typographyStyle)(Muted);
