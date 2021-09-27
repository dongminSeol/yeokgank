import { Dispatch } from "redux";
import { ActionTypes } from "./types";

export interface ChangeTabAction {
    type: ActionTypes.changeTab;
    payload: string;
}

export const changeTab = (tab: string) => {
    return (dispatch: Dispatch) => {
        dispatch<ChangeTabAction>({ type: ActionTypes.changeTab, payload: tab });
    };
};
