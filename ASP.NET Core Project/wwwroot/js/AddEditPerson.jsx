﻿class AddEditPerson extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            Name: '',
            Phone: '',
            CityId: ''
            //City: '',
            //Country: '',
            //Language: ''
        }
    }
    onSubmit = (e) => {
        debugger
        e.preventDefault();
        const data = {
            Name: this.state.Name,
            Phone: this.state.Phone,
            CityId: this.state.CityId
            //City: this.state.City,
            //Language: this.state.Language,
        }

        
        console.log("Submitted data", this.state)
        fetch("/React/AddEditPerson", {
            method: "POST",
            headers: { 'Content-Type': 'application/json', },
            body: JSON.stringify(data),
        }).then(response => respopnse.json())
            .then(data => {
                console.log("Success", data.success);
                alert(data.Message)
                window.location.href = "/React/Index";
            }).catch ((error) => {
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
            <div className="modal fade" id="AddEditModal" tabIndex="-1" aria-hidden="true">
                <div className="modal-dialog">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title">Add/Edit Person Info</h5>
                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
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
                            <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                            <button type="button" className="btn btn-primary btn-block" onClick={this.onSubmit}>Save</button>

                            {/*<input type="submit" value="Save" className="btn btn-primary btn-block" />*/}
                        </div>
                    </div>
                </div>
            </div>
        )
    }



    // Details Modal
    render() {
        return (
            <div className="modal fade" id="PersonDetailModal" tabIndex="-1" aria-hidden="true">
                <div className="modal-dialog">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title">Person Details</h5>
                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
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
                                <div className="mb-3">
                                    <label className="col-form-label">City</label>
                                    <select asp-for="CityId" className="form-control" asp-items="ViewBag.CityId"></select>
                                </div>
                                <div className="mb-3">
                                    <label htmlFor="txtCountry" className="col-form-label">Country</label>
                                    <input type="text" className="form-control" id="txtCountry" name="Country" value={this.state.Country} onChange={this.onChange} />
                                </div>
                                <div className="mb-3">
                                    <label htmlFor="txtLanguage" className="col-form-label">Language</label>
                                    <input type="text" className="form-control" id="txtLanguage" name="Language" value={this.state.Language} onChange={this.onChange} />
                                </div>
                            </form>
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}