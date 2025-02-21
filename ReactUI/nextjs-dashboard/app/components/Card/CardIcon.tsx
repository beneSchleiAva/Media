import React from 'react';
// nodejs library that concatenates classes
import classNames from 'classnames';
// nodejs library to set properties for components
// @material-ui/core components
import { createStyles, makeStyles, withStyles } from '@mui/styles';

// @material-ui/icons

// core components
import cardIconStyle from '../../assets/jss/material-dashboard-react/components/cardIconStyle';

function CardIcon({ ...props }: any) {
  const { classes, className, children, color, ...rest } = props;
  const cardIconClasses = classNames({
    [classes.cardIcon]: true,
    [classes[color + 'CardHeader']]: color,
    [className]: className !== undefined
  });
  return (
    <div className={cardIconClasses} {...rest}>
      {children}
    </div>
  );
}

// CardIcon.propTypes = {
//   classes: PropTypes.object.isRequired,
//   className: PropTypes.string,
//   color: PropTypes.oneOf([
//     "warning",
//     "success",
//     "danger",
//     "info",
//     "primary",
//     "rose"
//   ])
// };

export default withStyles(cardIconStyle)(CardIcon);
