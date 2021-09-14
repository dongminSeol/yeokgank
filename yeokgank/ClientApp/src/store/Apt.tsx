import { Action, Reducer } from 'redux';


export interface AptState {
    count: number;
}


export interface IncrementCountAction { type: 'INCREMENT_COUNT' }
export interface DecrementCountAction { type: 'DECREMENT_COUNT' }
export interface MakeMapsAction { type: 'MAKE_MAPS' }

export type KnownAction = IncrementCountAction | DecrementCountAction | MakeMapsAction ;

export const actionCreators = {
    increment: () => ({ type: 'INCREMENT_COUNT' } as IncrementCountAction),
    decrement: () => ({ type: 'DECREMENT_COUNT' } as DecrementCountAction),
    makeMaps: () =>({type : 'MAKE_MAPS' } as MakeMapsAction )
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

