import React from 'react';
// import PropTypes from 'prop-types';
// @material-ui/core components
import { createStyles, makeStyles, withStyles } from '@mui/styles';
// core components
import tableStyle from '../../assets/jss/material-dashboard-react/components/tableStyle';
import { Table, TableBody, TableCell, TableHead, TableRow } from '@mui/material';

function CustomTable({ ...props }: any) {
  const { classes, tableHead, tableData, tableHeaderColor } = props;
  return (
    <div className={classes.tableResponsive}>
      <Table className={classes.table}>
        {tableHead !== undefined ? (
          <TableHead className={classes[tableHeaderColor + 'TableHeader']}>
            <TableRow>
              {tableHead.map((prop: any, key: any) => {
                return (
                  <TableCell
                    className={classes.tableCell + ' ' + classes.tableHeadCell}
                    key={key}
                  >
                    {prop}
                  </TableCell>
                );
              })}
            </TableRow>
          </TableHead>
        ) : null}
        <TableBody>
          {tableData.map((prop: any, key: any) => {
            return (
              <TableRow key={key}>
                {prop.map((p: any, k: any) => {
                  return (
                    <TableCell className={classes.tableCell} key={k}>
                      {p}
                    </TableCell>
                  );
                })}
              </TableRow>
            );
          })}
        </TableBody>
      </Table>
    </div>
  );
}

CustomTable.defaultProps = {
  tableHeaderColor: 'gray'
};

// CustomTable.propTypes = {
//   classes: PropTypes.object.isRequired,
//   tableHeaderColor: PropTypes.oneOf([
//     'warning',
//     'primary',
//     'danger',
//     'success',
//     'info',
//     'rose',
//     'gray'
//   ]),
//   tableHead: PropTypes.arrayOf(PropTypes.string),
//   tableData: PropTypes.arrayOf(PropTypes.arrayOf(PropTypes.string))
// };

export default withStyles(tableStyle)(CustomTable);
