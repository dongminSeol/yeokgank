import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { Link } from 'react-router-dom';
import { ApplicationState } from '../store';
import * as RegionStore from '../store/Region';

// At runtime, Redux will merge together...
type RegionProps =
    RegionStore.RegionState // ... state we've requested from the Redux store
    & typeof RegionStore.actionCreators // ... plus action creators we've requested
    & RouteComponentProps<{ pageIndex: string }>; // ... plus incoming routing parameters


class RegionData extends React.PureComponent<RegionProps> {
    // This method is called when the component is first added to the document
    public componentDidMount() {
        this.ensureDataFetched();
    }

    // This method is called when the route parameters change
    public componentDidUpdate() {
        this.ensureDataFetched();
    }

    public render() {
        return (
            <React.Fragment>
                <h1 id="tabelLabel">시,군,구 정보</h1>
                <p>좌표 정보</p>
                {this.renderRegionTable()}
                {this.renderPagination()}
            </React.Fragment>
        );
    }

    private ensureDataFetched() {

        const pageIndex = parseInt(this.props.match.params.pageIndex, 10) || 1;
        this.props.requestRegionCode(pageIndex);
    }

    private editCode(id: number, name: string, email: string){
        //this.props.setUserToBeEdited(id, name, email);
        //this.props.changeTab("editUser");
    };


    private renderRegionTable() {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Lat</th>
                        <th>Lng</th>
                        <th>RegionCode</th>
                        <th>Address</th>
                        <th>수정</th>
                        <th>삭제</th>
                    </tr>
                </thead>
                <tbody>
                    {this.props.regions.region.map((region: RegionStore.RegionData) =>
                        <tr key={region.address}>
                            <td>{region.lat}</td>
                            <td>{region.lng}</td>
                            <td>{region.regionCode}</td>
                            <td>{region.address}</td>
                            <td>
                                <button onClick={ ()=> { this.editCode(0, "", "") }} />
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    private renderPagination() {
        const prevpageIndex = (this.props.pageIndex || 0) - 1;
        const nextpageIndex = (this.props.pageIndex || 1) + 1;

        return (
            <div className="d-flex justify-content-between">
                {prevpageIndex != 0 && <Link className='btn btn-outline-secondary btn-sm' to={`/region-data/${prevpageIndex}`}>이전</Link>}
                {this.props.isLoading && <span>Loading...</span>}
                <Link className='btn btn-outline-secondary btn-sm' to={`/region-data/${nextpageIndex}`}>다음</Link>
            </div>
        );
    }
}

export default connect(
    (state: ApplicationState) => state.region, // Selects which state properties are merged into the component's props
    RegionStore.actionCreators // Selects which action creators are merged into the component's props
)(RegionData as any);
