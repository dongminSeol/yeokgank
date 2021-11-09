import { TradeInfoActionTypes } from "./tradeInfoActionsTypes";
import { TradeInfo } from "../reducers/tradeInfo-reducer"
import {TradeRequest} from '../models/trade-request.model'
import { AppThunkAction } from '../reducers';
import api from '../api/api';

export interface GetYear {
    requset :TradeRequest;
    type: TradeInfoActionTypes.getYear;
    payload: TradeInfo[];
}

export interface GetMonth {
    requset :TradeRequest;
    type: TradeInfoActionTypes.getMonth;
    payload: TradeInfo[];
}
export interface GetDay {
    requset :TradeRequest;
    type: TradeInfoActionTypes.getDay;
    payload: TradeInfo[];
}
type KnownAction =
    | GetYear
    | GetMonth
    | GetDay;


export const tradeActionCreators = {
    getMonth: (req: TradeRequest ): AppThunkAction<KnownAction> => async (dispatch , getState) => {
        try
        {
            console.log(req);
            const appState = getState();
            if (appState && appState.tradeinfo && req != appState.tradeinfo.request) {
                console.log(req);
                const response = await api.get("/api/trade/month", {
                    params: req
                });
                console.log(response);
                dispatch({
                    type: TradeInfoActionTypes.getMonth,
                    payload: response.data.apartmentTrade,
                    requset: req
                });
            }
        }
        catch (err)
        {
            console.log(err);
        }
    }
    
};
