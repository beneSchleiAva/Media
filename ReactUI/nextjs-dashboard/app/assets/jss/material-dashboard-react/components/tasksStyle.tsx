import {
  defaultFont,
  primaryColor,
  dangerColor,
  grayColor
} from '../../material-dashboard-react';
import tooltipStyle from '../tooltipStyle';
import checkboxAdnRadioStyle from '../checkboxAdnRadioStyle';
import { createStyles, makeStyles, withStyles } from '@mui/styles';

const tasksStyle = createStyles({
  ...tooltipStyle,
  ...checkboxAdnRadioStyle,
  table: {
    marginBottom: '0',
    overflow: 'visible'
  },
  tableRow: {
    position: 'relative',
    borderBottom: '1px solid ' + grayColor[5]
  },
  tableActions: {
    display: 'flex',
    border: 'none',
    padding: '12px 8px !important',
    verticalAlign: 'middle'
  },
  tableCell: {
    ...defaultFont,
    padding: '8px',
    verticalAlign: 'middle',
    border: 'none',
    lineHeight: '1.42857143',
    fontSize: '14px'
  },
  tableCellRTL: {
    textAlign: 'right'
  },
  tableActionButton: {
    width: '27px',
    height: '27px',
    padding: '0'
  },
  tableActionButtonIcon: {
    width: '17px',
    height: '17px'
  },
  edit: {
    backgroundColor: 'transparent',
    color: primaryColor[0],
    boxShadow: 'none'
  },
  close: {
    backgroundColor: 'transparent',
    color: dangerColor[0],
    boxShadow: 'none'
  }
});
export default tasksStyle;
