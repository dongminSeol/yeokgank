"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.changeTab = void 0;
var types_1 = require("./types");
exports.changeTab = function (tab) {
    return function (dispatch) {
        dispatch({ type: types_1.ActionTypes.changeTab, payload: tab });
    };
};
//# sourceMappingURL=tap-actions.js.map