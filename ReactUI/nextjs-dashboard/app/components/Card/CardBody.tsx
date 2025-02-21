import React from 'react';
// nodejs library that concatenates classes
import classNames from 'classnames';
import { createStyles, makeStyles, withStyles } from '@mui/styles';
// @material-ui/icons

// core components
import cardBodyStyle from '../../assets/jss/material-dashboard-react/components/cardBodyStyle';

function CardBody({ ...props }: any) {
  const { classes, className, children, plain, profile, ...rest } = props;
  const cardBodyClasses = classNames({
    [classes.cardBody]: true,
    [classes.cardBodyPlain]: plain,
    [classes.cardBodyProfile]: profile,
    [className]: className !== undefined
  });
  return (
    <div className={cardBodyClasses} {...rest}>
      {children}
    </div>
  );
}

// CardBody.propTypes = {
//   classes: PropTypes.object.isRequired,
//   className: PropTypes.string,
//   plain: PropTypes.bool,
//   profile: PropTypes.bool
// };

export default withStyles(cardBodyStyle)(CardBody);
