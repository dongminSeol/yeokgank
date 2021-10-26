import { Action, Reducer } from 'redux';
import { AppThunkAction } from '.';

export interface AptState {
    count: number;
}
export interface TradeDataList
{
    trade: TradeData[];
}
export interface TradeData
{
    dealDate:string;
    sigunguCode:string;
    sigunguName:string;
    cnt:number;
}
interface RequestTradeAction{
    type: 'REQUEST_TRADE';
    pageIndex: number;
}
interface ReceiveTradeAction{
    type: 'RECEIVE_TRADE';
    h_cd:string;
    m_cd:string;
    s_date:string;
    e_date:string;
}
export type KnownAction = RequestTradeAction | ReceiveTradeAction 

function objToQueryString(obj: any) {
    const keyValuePairs = [];
    for (const key in obj) {
        keyValuePairs.push(encodeURIComponent(key) + '=' + encodeURIComponent(obj[key]));
    }
    return keyValuePairs.join('&');
}
export const actionCreators = {
    requestRegionCode: (pageIndex: number): AppThunkAction<KnownAction> => (dispatch, getState) => {

        const queryString = objToQueryString({
            page: pageIndex ,
            size: 10
        });

        const appState = getState();
        if (appState && appState. && pageIndex !== appState.region.pageIndex) {
            fetch(`/api/trade/month?${queryString}`)
                .then(response => response.json() as Promise<TradeDataList>)
                .then(data => {
                    dispatch({
                        type: 'RECEIVE_TRADE',
                        h_cd : '',
                        h_cd : '',
                        h_cd : '',
                    });
                });

            dispatch({
                type: 'RECEIVE_TRADE'
            });
        }
    }
};
export const reducer: Reducer<AptState> = (state: AptState | undefined, incomingAction: Action): AptState => {
    if (state === undefined) {
        return { count: 0 };
    }

    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'INCREMENT_COUNT':
            return { count: state.count + 1 };
        case 'DECREMENT_COUNT':
            return { count: state.count - 1 };
        default:
            return state;
    }
};

