import * as Trade from "./tradeInfo-reducer";
import * as RegionCode from "./region-reducer";

// 최상위 상태 개체
export interface ApplicationState {
    tradeinfo: Trade.TradeState | undefined;
    regioncode: RegionCode.RegionState | undefined;
}

//작업이 발생 때마다 Redux는 다음을 각 최상위 상태 속성을 업데이트합니다.
//일치하는 이름을 가진 Reducer ApplicationState 속성 유형에 적용됩니다.

export const reducers = {
    tradeinfo: Trade.tradeReducer,
    regioncode: RegionCode.regionReducer
};

// 'dispatch'와 'getState' 매개 변수가 다음과 작업 기준으로 사용할 수 있습니다.
export interface AppThunkAction<TAction> {
    (dispatch: (action: TAction) => void, getState: () => ApplicationState): void;
}