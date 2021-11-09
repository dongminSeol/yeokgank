import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../reducers/index';
import * as Store from '../reducers/region-reducer'
import { regionActionCreators } from "../actions";

type RegionProps = Store.RegionState
    & typeof regionActionCreators
    & RouteComponentProps<{
        page: string,
        size: string
    }>;



class RegionCodePage extends React.PureComponent<RegionProps> {
    public componentDidMount() {
        this.ensureData();
    }
    public componentDidUpdate() {
        this.ensureData();
    }

    public render() {
        return (
            <React.Fragment>
                <h1 id="tabelLabel">시,군,구 정보</h1>
                <p>좌표 정보</p>
                {this.renderTable()}
            </React.Fragment>
        );
    }

    private ensureData() {
        this.props.getSeoulCode({
              page: parseInt(this.props.match.params.page, 10) || 1
            , size: parseInt(this.props.match.params.size, 10) || 10
            , h_cd: "11"
            , m_cd :""
            , s_cd: ""
            , t_cd :""
        })
    }


    private renderTable() {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>시,군구</th>
                        <th>Lat</th>
                        <th>Lng</th>
                    </tr>
                </thead>
                <tbody>
                    {this.props.items.map((item: Store.Region) =>
                        <tr key={item.regionCode}>
                            <td>{item.address}</td>
                            <td>{item.lat}</td>
                            <td>{item.lng}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    //private renderPagination() {
    //    const prevpageIndex = (this.props.pageIndex || 0) - 1;
    //    const nextpageIndex = (this.props.pageIndex || 1) + 1;

    //    return (
    //        <div className="d-flex justify-content-between">
    //            {prevpageIndex != 0 && <Link className='btn btn-outline-secondary btn-sm' to={`/region-data/${prevpageIndex}`}>이전</Link>}
    //            {this.props.isLoading && <span>Loading...</span>}
    //            <Link className='btn btn-outline-secondary btn-sm' to={`/region-data/${nextpageIndex}`}>다음</Link>
    //        </div>
    //    );
    //}
}

export default connect(
    (state: ApplicationState) => state.regioncode,
    regionActionCreators
)(RegionCodePage as any);