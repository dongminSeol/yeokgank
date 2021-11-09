import { RegionActionTypes } from "./regionActionsTypes";
import { Region } from "../reducers/region-reducer"
import { RegionRequest } from '../models/region-request.model'
import { AppThunkAction } from '../reducers';
import api from '../api/api';

export interface GetSeoulCode {
    requset: RegionRequest;
    type: RegionActionTypes.getSeoulCode;
    payload: Region[];
}

type KnownAction = | GetSeoulCode;


export const regionActionCreators = {
    getSeoulCode: (req: RegionRequest ): AppThunkAction<KnownAction> => async (dispatch , getState) => {
        try
        {
            const appState = getState();
            if (appState && appState.regioncode && req !== appState.regioncode.request) {
                console.log(req);
                const response = await api.get("/api/region/list", {
                    params: req
                });
                console.log(response);
                dispatch({
                    type: RegionActionTypes.getSeoulCode,
                    payload: response.data.region,
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
