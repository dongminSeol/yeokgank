import { Action, Reducer } from 'redux';
import { AppThunkAction } from '.';
import Region from '../components/Region';

export interface RegionState {
    isLoading: boolean;
    pageIndex?: number;
    regions: RegionDataList;
}

export interface RegionDataList {
    region: RegionData[];
    paginginfo: PagingInfo;
}


export interface RegionData {
    address: string;
    lat: string;
    lng: string;
    regionCode: string;
    ad_h_nm: string;
    ad_m_nm: string;
    ad_s_nm: string;
    ad_t_nm: string;
}

export interface PagingInfo {
    totalItems?: number;
    itemsPerPage?: number;
    currentPage?: number;
    totalPages?: number;
}

interface RequestRegionAction {
    type: 'REQUEST_REGION';
    pageIndex: number;
}

interface ReceiveRegionAction {
    type: 'RECEIVE_REGION';
    pageIndex: number;
    regions: RegionDataList;
}

type KnownAction = RequestRegionAction | ReceiveRegionAction;

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
        if (appState && appState.region && pageIndex !== appState.region.pageIndex) {
            fetch(`/api/region/list?${queryString}`)
                .then(response => response.json() as Promise<RegionDataList>)
                //.then(data => console.log(data.regiondata));
                .then(data => {
                    dispatch({
                        type: 'RECEIVE_REGION',
                        pageIndex: pageIndex,
                        regions: data
                    });
                });

            dispatch({
                type: 'REQUEST_REGION',
                pageIndex: pageIndex
            });
        }
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

//const unloadedState: RegionState = { regiondatalist: , isLoading: false };
const unloadedState: RegionState = {
    regions: {
        region: [],
        paginginfo: {
        }
    },
    isLoading: false
};

export const reducer: Reducer<RegionState> = (state: RegionState | undefined, incomingAction: Action): RegionState => {
    if (state === undefined) {
        return unloadedState;
    }

    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'REQUEST_REGION':
            return {
                pageIndex: action.pageIndex,
                regions: state.regions,
                isLoading: true
            };
        case 'RECEIVE_REGION':
            //수신 데이터가 가장 최근의 요청과 일치하는 경우에만 
            // 이렇게 하면 정확할 수 있습니다. 잘못된 응답을 처리합니다.
            if (action.pageIndex === state.pageIndex) {
                return {
                    pageIndex: action.pageIndex,
                    regions: action.regions,
                    isLoading: false
                };
            }
            break;
    }

    return state;
};
