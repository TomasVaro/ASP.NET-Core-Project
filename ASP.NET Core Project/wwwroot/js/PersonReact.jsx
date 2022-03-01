class Index extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            Personlist: [{}],
            Id: "",
            IsModalOpen: false,
            IsDetailsModalOpen: false,
            IsDeleteModalOpen: false
        }
    }

    componentDidMount() {
        this.getPerson()
    }

    getPerson = () => {
        fetch("/React/PersonList").then(response => response.json())
            .then(data => {
                this.setState({ Personlist: data })
            })
    }

    sortAtoZ() {
        this.setState(this.state.Personlist.sort(function (a, b) {
            if (a.name.toLowerCase() < b.name.toLowerCase()) return -1;
            if (a.name.toLowerCase() > b.name.toLowerCase()) return 1;
            return 0;
        })
            .map((item, i) => <Personlist key={i} data={item} />)
        );
    }

    sortZtoA() {
        this.setState(this.state.Personlist.sort(function (a, b) {
            if (a.name.toLowerCase() < b.name.toLowerCase()) return 1;
            if (a.name.toLowerCase() > b.name.toLowerCase()) return -1;
            return 0;
        })
            .map((item, i) => <Personlist key={i} data={item} />)
        );
    }

    sortById() {
        this.setState(this.state.Personlist.sort(function (a, b) {
            if (a.personId < b.personId) return -1;
            if (a.personId > b.personId) return 1;
            return 0;
        })
            .map((item, i) => <Personlist key={i} data={item} />)
        );
    }

    render() {
        const row = this.state.Personlist.map((list, i) => {
            return (
                <tr key={i}>
                    <td>{list.personId}</td>
                    <td>{list.name}</td>
                    <td>
                        <button type="button" className="btn btn-primary detailsButton" data-bs-toggle="modal" data-bs-target="#PersonDetailsModal"
                            onClick={() => { this.setState({ IsDetailsModalOpen: true, Id: list.personId }) }}>Details</button>
                        <span>|</span>
                        <button type="button" className="btn btn-primary editButton" data-bs-toggle="modal" data-bs-target="#AddEditModal"
                            onClick={() => { this.setState({ IsModalOpen: true, Id: list.personId }) }}>Edit</button>
                        <span>|</span>
                        <button type="button" className="btn btn-danger deleteButton" data-bs-toggle="modal" data-bs-target="#DeletePersonModal"
                            onClick={() => { this.setState({ IsDeleteModalOpen: true, Id: list.personId }) }}>Delete</button>
                    </td>
                </tr>
            )
        })
        return (
            <div>
                <div className="float-right mr-4 mb-2">
                    <button type="button" className="btn btn-primary addButton" data-bs-toggle="modal" data-bs-target="#AddEditModal"
                        onClick={() => { this.setState({ IsModalOpen: true, Id: "" }) }}>Add</button>
                </div>
                <table className="table">
                    <thead className="table-light">
                        <tr>
                            <th scope="col">Id</th>
                            <th scope="col">Name</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        {row}
                    </tbody>
                </table>
                <button type="button" className="btn btn-primary sortButton" data-bs-toggle="modal" data-bs-target="#SortPerson"
                    onClick={() => { this.setState({ IsSorted: true }), this.sortAtoZ() }}>Sort A-Z</button>
                <span>|</span>
                <button type="button" className="btn btn-primary sortButton" data-bs-toggle="modal" data-bs-target="#SortPerson"
                    onClick={() => { this.setState({ IsSorted: true }), this.sortZtoA() }}>Sort Z-A</button>
                <span>|</span>
                <button type="button" className="btn btn-primary sortButton" data-bs-toggle="modal" data-bs-target="#SortPerson"
                    onClick={() => { this.setState({ IsSorted: true }), this.sortById() }}>Sort by Id</button>

                {/*Pass Id to the Props*/}
                {/*{console.log("Submitted", this.state.Id)}*/}
                {/*{console.log("ModalState", this.state.IsModalOpen)}*/}
                {/*{console.log("DetailsModalState", this.state.IsDetailsModalOpen)}*/}
                {/*{console.log("DeleteModalState", this.state.IsDeleteModalOpen)}*/}
                {this.state.IsModalOpen == true ? < AddEditPerson id={this.state.Id} CloseModal={() => { this.setState({ IsModalOpen: false }) }} /> : null}
                {this.state.IsDetailsModalOpen == true ? < PersonDetails id={this.state.Id} CloseModal={() => { this.setState({ IsDetailsModalOpen: false }) }} /> : null}
                {this.state.IsDeleteModalOpen == true ? < DeletePerson id={this.state.Id} CloseModal={() => { this.setState({ IsDeleteModalOpen: false }) }} reload={ this.getPerson() }/> : null}
                {/*<AddEditPerson/>*/}
                {/*<PersonDetails />*/}
            </div>
        )
    }
}


class AddEditPerson extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            PersonId: 0,
            Name: '',
            Phone: '',
            CityId: 0
            //City: '',
            //Country: '',
            //Language: ''
        }
    }

    componentDidMount() {
        if (this.props.id > 0) {
            fetch("/React/GetById?id=" + this.props.id)
                .then(response => response.json())
                .then(data => {
                    this.setState({
                        PersonId: data.personId,
                        Name: data.name,
                        Phone: data.phone,
                        CityId: data.cityId
                    })
                })
        }
    }

    onSubmit = (e) => {
        e.preventDefault();
        const data = {
            PersonId: this.state.PersonId,
            Name: this.state.Name,
            Phone: this.state.Phone,
            CityId: parseInt(this.state.CityId)
            //City: this.state.City,
            //Language: this.state.Language,
        }

        console.log("Submitted data", data);
        console.log("Submitted stringify data", JSON.stringify(data));

        fetch("/React/AddEditPerson", {
            method: "POST",
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        })
            .then(response => response.json())
            .then(data => {
                console.log("Success", data.success);
                alert(data.Message)
                window.location.href = "/React/Index";
            })
            .catch((error) => {
                console.log("Error", data.error);
                alert(data.Message)
            })
    }

    onChange = (e) => {
        this.setState({
            [e.target.name]: e.target.value
        })
    }

    // Add/Edit Person Modal
    render() {
        return (
            <div className="modal fade" id="AddEditModal" data-bs-backdrop="static" data-bs-keyboard="false" tabIndex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                <div className="modal-dialog">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title">Add/Edit Person</h5>
                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true" onClick={this.props.CloseModal}>&times;</span>
                            </button>
                        </div>
                        <div className="modal-body">
                            <form>
                                <div className="mb-3">
                                    <label htmlFor="txtName" className="col-form-label">Name</label>
                                    <input type="text" className="form-control" id="txtName" name="Name" value={this.state.Name} onChange={this.onChange} />
                                </div>
                                <div className="mb-3">
                                    <label htmlFor="txtPhone" className="col-form-label">Phone</label>
                                    <input type="text" className="form-control" id="txtPhone" name="Phone" value={this.state.Phone} onChange={this.onChange} />
                                </div>
                                {/*<div className="mb-3">*/}
                                {/*    <label className="col-form-label">City</label>*/}
                                {/*    <select asp-for="CityId" className="form-control" asp-items="ViewBag.CityId"></select>*/}
                                {/*</div>*/}
                                <div className="mb-3">
                                    <label htmlFor="txtCity" className="col-form-label">CityId</label>
                                    <input type="number" className="form-control" id="txtCity" name="CityId" value={this.state.CityId} onChange={this.onChange} />
                                </div>
                                {/*<div className="mb-3">*/}
                                {/*    <label htmlFor="txtCountry" className="col-form-label">Country</label>*/}
                                {/*    <input type="text" className="form-control" id="txtCountry" name="Country" value={this.state.Country} onChange={this.onChange} />*/}
                                {/*</div>*/}
                                {/*<div className="mb-3">*/}
                                {/*    <label htmlFor="txtLanguage" className="col-form-label">Language</label>*/}
                                {/*    <input type="text" className="form-control" id="txtLanguage" name="Language" value={this.state.Language} onChange={this.onChange} />*/}
                                {/*</div>*/}
                            </form>
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-secondary" data-bs-dismiss="modal" onClick={this.props.CloseModal}>Close</button>
                            <button type="button" className="btn btn-primary btn-block" onClick={this.onSubmit}>Save</button>


                            {/*<input type="submit" value="Save" className="btn btn-primary btn-block" />*/}
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}



class DeletePerson extends React.Component {
    constructor(props) {
        super(props)

        }
    onDelete = () => {
        fetch("/PeopleEF/DeletePerson?id=" + this.props.id)
            .then(response => response.json())
            .then(data => {
                alert(data.Mesage);
                this.props.reload();
            })
    }
    render() {
        return (
            <div className="modal" id="DeletePersonModal" tabIndex="-1">
                <div className="modal-dialog">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title">Delete Person</h5>
                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div className="modal-body">
                            <p>Are you sure you want to delete this Person?</p>
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                            <button type="button" className="btn btn-primary" data-bs-dismiss="modal" onClick={this.onDelete.bind(this)}>Ok</button>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}


class PersonDetails extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            PersonId: 0,
            Name: '',
            Phone: '',
            CityId: ''
            //City: '',
            //Country: '',
            //Language: ''
        }
    }

    componentDidMount() {
        console.log("Submitted props.id", this.props.id);
        if (this.props.id > 0) {
            fetch("/React/GetById?id=" + this.props.id)
                .then(response => response.json())
                .then(data => {
                    this.setState({
                        PersonId: data.personId,
                        Name: data.name,
                        Phone: data.phone,
                        CityId: data.cityId,
                        //City: data.city,
                        //Country: data.country,
                        //Language: data.language
                    })
                    console.log("Submitted state.name", this.state.Name);
                    console.log("Submitted state.cityId", this.state.CityId);
                })
        }
    }

    //Person Detail Modal
    render() {
        return (
            <div className="modal fade" id="PersonDetailsModal" data-bs-backdrop="static" data-bs-keyboard="false" tabIndex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                <div className="modal-dialog">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title">Person Details</h5>
                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true" onClick={this.props.CloseModal}>&times;</span>
                            </button>
                        </div>
                        <div className="modal-body">
                            <form>
                                <div className="mb-3">
                                    <label htmlFor="txtName" className="col-form-label">Name</label>
                                    <input type="text" className="form-control" id="txtName" name="Name" defaultValue={this.state.Name} />
                                </div>
                                <div className="mb-3">
                                    <label htmlFor="txtPhone" className="col-form-label">Phone</label>
                                    <input type="text" className="form-control" id="txtPhone" name="Phone" defaultValue={this.state.Phone} />
                                </div>
                                <div className="mb-3">
                                    <label htmlFor="txtCityId" className="col-form-label">CityId</label>
                                    <input type="text" className="form-control" id="txtCityId" name="CityId" defaultValue={this.state.CityId} />
                                    {/*<select asp-for="CityId" className="form-control" asp-items="ViewBag.CityId"></select>*/}
                                </div>
                                {/*<div className="mb-3">*/}
                                {/*    <label htmlFor="txtCity" className="col-form-label">City</label>*/}
                                {/*    <input type="text" className="form-control" id="txtCity" name="City" defaultValue={this.state.City}/>*/}
                                {/*    */}{/*<select asp-for="City" className="form-control" asp-items="ViewBag.City"></select>*/}
                                {/*</div>*/}
                                {/*<div className="mb-3">*/}
                                {/*    <label htmlFor="txtCountry" className="col-form-label">Country</label>*/}
                                {/*    <input type="text" className="form-control" id="txtCountry" name="Country" defaultValue={this.state.Country}/>*/}
                                {/*</div>*/}
                                {/*<div className="mb-3">*/}
                                {/*    <label htmlFor="txtLanguage" className="col-form-label">Language</label>*/}
                                {/*    <input type="text" className="form-control" id="txtLanguage" name="Language" defaultValue={this.state.Language}/>*/}
                                {/*</div>*/}
                            </form>
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-secondary" data-bs-dismiss="modal" onClick={this.props.CloseModal}>Close</button>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}

ReactDOM.render(<Index />, document.getElementById("Personlist"))