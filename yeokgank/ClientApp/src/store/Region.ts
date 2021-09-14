import { Action, Reducer } from 'redux';
import { AppThunkAction } from '.';

export interface RegionState {
    isLoading: boolean;
    startDateIndex?: number;
    region: Region[];
}

export interface Region {
    address: string;
    lat: string;
    lng: string;
    regionCode: string;
}


interface RequestMapAction {
    type: 'REQUEST_MAP';
    startDateIndex: number;
}

interface ReceiveMapAction {
    type: 'RECEIVE_MAP';
    startDateIndex: number;
    region: Region[];
}

type KnownAction = RequestMapAction | ReceiveMapAction;



export const actionCreators = {
    requestMap: (startDateIndex: number): AppThunkAction<KnownAction> => (dispatch, getState) => {

        const appState = getState();
        if (appState && appState.region && startDateIndex !== appState.region.startDateIndex) {
            fetch('region')
                .then(response => response.json() as Promise<Region[]>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_MAP', startDateIndex: startDateIndex, region: data });
                });

            dispatch({ type: 'REQUEST_MAP', startDateIndex: startDateIndex });
        }
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: RegionState = { region: [], isLoading: false };

export const reducer: Reducer<RegionState> = (state: RegionState | undefined, incomingAction: Action): RegionState => {
    if (state === undefined) {
        return unloadedState;
    }

    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'REQUEST_MAP':
            return {
                startDateIndex: action.startDateIndex,
                region: state.region,
                isLoading: true
            };
        case 'RECEIVE_MAP':
            //수신 데이터가 가장 최근의 요청과 일치하는 경우에만 
            // 이렇게 하면 정확할 수 있습니다. 잘못된 응답을 처리합니다.
            if (action.startDateIndex === state.startDateIndex) {
                return {
                    startDateIndex: action.startDateIndex,
                    region: action.region,
                    isLoading: false
                };
            }
            break;
    }

    return state;
};
