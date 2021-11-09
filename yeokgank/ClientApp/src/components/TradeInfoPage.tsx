import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../reducers/index';
import * as Store from '../reducers/tradeInfo-reducer'
import { tradeActionCreators } from "../actions";

type TradeInfoPageProps = Store.TradeState
    & typeof tradeActionCreators
    & RouteComponentProps<{
          h_cd: string
        , m_cd: string
        , s_date: string
        , e_date: string
    }>;

class TradeInfoPage extends React.PureComponent<TradeInfoPageProps>
{
    public componentDidMount() {
        this.ensureTradeData();
    }

    public componentDidUpdate() {
        this.ensureTradeData();
    }
    private ensureTradeData() {
        //this.props.getMonth({
        //    h_cd: (this.props.match.params.h_cd || "11"),
        //    m_cd: (this.props.match.params.m_cd || "000"),
        //    s_date: (this.props.match.params.s_date || "202107"),
        //    e_date: (this.props.match.params.e_date || "202111")
        //})
      }
    public render() {
        return (
            <React.Fragment>
                <p id="tabelLabel">공공데이터포털 국토교통부 자료를 계약일 기준으로 집계하여 제공하고있습니다.</p>
                {this.renderTable()}
            </React.Fragment>
        );
    }

    private renderTable() {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead className="bg-light">
                    <tr>
                        <th scope="col">날짜</th>
                        <th scope="col">구분</th>
                        <th scope="col">거래량</th>
                    </tr>
                </thead>
                <tbody>
                    {this.props.items.map((item: Store.TradeInfo) =>
                        <tr key={item.dealDate}>
                            <td>{item.dealDate}</td>
                            <td>{item.sigunguName}</td>
                            <td>{item.cnt}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }


}

export default connect(
    (state: ApplicationState) => state.tradeinfo,
    tradeActionCreators
)(TradeInfoPage as any);