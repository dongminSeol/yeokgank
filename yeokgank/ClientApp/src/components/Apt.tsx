import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import * as AptStore from '../store/Apt';

type AptProps =
    AptStore.AptState &
    typeof AptStore.actionCreators &
    RouteComponentProps<{}>;

class Apt extends React.PureComponent<AptProps> {
    public render() {
        return (
            <React.Fragment>
                <h1>아파트</h1>

                <p>샘플 데이터</p>
                <div></div>

                {/* <p aria-live="polite">Current count: <strong>{this.props.count}</strong></p> */}

                {/* <button type="button"
                    className="btn btn-primary btn-lg"
                    onClick={() => { this.props.increment(); }}>
                    Increment
                </button> */}
                {this.renderKaKaoMap()}
            </React.Fragment>
        );
    }
    private renderKaKaoMap() {
        return (
            <div>123</div>
        );
      }
    
};

export default connect
(
    (state: ApplicationState) => state.counter, AptStore.actionCreators
)(Apt);
