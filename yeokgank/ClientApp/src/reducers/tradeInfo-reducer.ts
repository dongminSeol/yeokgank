import { Reducer } from 'redux';
import { TradeInfoAction, TradeInfoActionTypes } from "../actions";
import {TradeRequest} from '../models/trade-request.model'
export interface TradeState {
    items: TradeInfo [];
    isLoading: boolean;
    error: String | null;
    request : TradeRequest
}

export interface TradeInfo {
    dealDate: string;
    sigunguName: string;
    cnt: number;
}
export const tradeReducer: Reducer<TradeState, TradeInfoAction> = (state: TradeState | undefined, action: TradeInfoAction) => {
    if (state === undefined) {
        return {
              isLoading: false
            , error: "error..."
            , items: []
            ,request : { h_cd : "", m_cd : "", s_date : "", e_date:"" } as TradeRequest
        };
    }
    switch (action.type) {
        case TradeInfoActionTypes.getMonth:
            return {
                isLoading: true,
                error: null,
                items: action.payload,
                request: action.requset
            };
        case TradeInfoActionTypes.getYear:
            return {
                isLoading: true,
                error: null,
                items: action.payload,
                request: action.requset
            };
        default:
            return state;
    }
};
