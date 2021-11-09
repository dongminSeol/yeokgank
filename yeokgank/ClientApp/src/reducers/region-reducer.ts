import { Reducer } from 'redux';
import { RegionAction, RegionActionTypes } from "../actions";
import { RegionRequest } from '../models/region-request.model'
export interface RegionState {
    items: Region[];
    isLoading: boolean;
    error: String | null;
    request: RegionRequest
}

export interface Region {
    ad_h_nm: string;
    ad_m_nm: string;
    ad_s_nm: string;
    ad_t_nm: string;
    lat: string;
    lng: string;
    regionCode: string;
    address: string;
}
export const regionReducer: Reducer<RegionState, RegionAction> = (state: RegionState | undefined, action: RegionAction) => {
    if (state === undefined) {
        return {
            isLoading: false
            , error: "error..."
            , items: [] 
            , request: {  } as RegionRequest
        };
    }
    switch (action.type) {
        case RegionActionTypes.getSeoulCode:
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
