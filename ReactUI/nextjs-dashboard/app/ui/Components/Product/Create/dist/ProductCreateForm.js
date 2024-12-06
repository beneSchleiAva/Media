"use strict";
exports.__esModule = true;
var React = require("react");
var Button_1 = require("@mui/material/Button");
var material_1 = require("@mui/material");
var react_hook_form_1 = require("react-hook-form");
var Grid2_1 = require("@mui/material/Grid2");
function ProductCreateForm() {
    var _a = react_hook_form_1.useForm(), control = _a.control, handleSubmit = _a.handleSubmit;
    var onSubmit = function (data) {
        console.log(data);
    };
    return (React.createElement("form", { onSubmit: handleSubmit(onSubmit) },
        React.createElement(Grid2_1["default"], { container: true, spacing: 2 },
            React.createElement(Grid2_1["default"], { size: 8 },
                React.createElement(react_hook_form_1.Controller, { name: 'name', control: control, defaultValue: "", render: function (_a) {
                        var field = _a.field;
                        return (React.createElement(material_1.TextField, { placeholder: "Name of the product", required: true }));
                    } })),
            React.createElement(Grid2_1["default"], { size: 8 },
                React.createElement(react_hook_form_1.Controller, { name: 'description', control: control, defaultValue: "", render: function (_a) {
                        var field = _a.field;
                        return (React.createElement(material_1.TextField, { placeholder: "Description of the product", required: true }));
                    } })),
            React.createElement(Grid2_1["default"], { size: 8 },
                React.createElement(react_hook_form_1.Controller, { name: 'price', control: control, defaultValue: 0, render: function (_a) {
                        var field = _a.field;
                        return (React.createElement(material_1.TextField, { placeholder: "Price of the product", required: true, type: 'number' }));
                    } }))),
        React.createElement(Button_1["default"], { type: "submit" }, "Submit")));
}
exports["default"] = ProductCreateForm;
