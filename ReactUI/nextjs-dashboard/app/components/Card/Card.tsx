import React from 'react';
// nodejs library that concatenates classes
import classNames from 'classnames';
// nodejs library to set properties for components
// import PropTypes from "prop-types";
// @material-ui/core components
import { createStyles, makeStyles, withStyles } from '@mui/styles';

// @material-ui/icons

// core components
import cardStyle from '../../assets/jss/material-dashboard-react/components/cardStyle';

function Card({ ...props }: any) {
  const {
    classes,
    className,
    children,
    plain,
    profile,
    chart,
    ...rest
  } = props;
  const cardClasses = classNames({
    [classes.card]: true,
    [classes.cardPlain]: plain,
    [classes.cardProfile]: profile,
    [classes.cardChart]: chart,
    [className]: className !== undefined
  });
  return (
    <div className={cardClasses} {...rest}>
      {children}
    </div>
  );
}

// Card.propTypes = {
//   classes: PropTypes.object.isRequired,
//   className: PropTypes.string,
//   plain: PropTypes.bool,
//   profile: PropTypes.bool,
//   chart: PropTypes.bool
// };

export default withStyles(cardStyle)(Card);
