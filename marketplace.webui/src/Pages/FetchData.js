import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { Categories: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderCategoriesTable(Categories) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel" align='center'>
        <thead>
          <tr>
            <th>Name</th>
          </tr>
        </thead>
        <tbody>
          {Categories.map(category =>
            <tr key={category.nameGlobalCategory}>
              <td>
                <div>
                    <table className='table table-striped' aria-labelledby="tabelLabel">
                        <thead>
                            <th align='left' >{category.nameGlobalCategory} </th>
                            <th align='right'><button name='Add'>Добавить</button></th>
                        </thead>
                        <tbody>
                            {category.categories.map(subcat =>
                                <tr key={subcat.nameCategory}>
                                    <td>{subcat.nameCategory}</td>
                                    <td></td>
                                </tr>
                            )}
                        </tbody>
                    </table>
                    
                </div>
              </td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderCategoriesTable(this.state.Categories);

    return (
      <div>
        <h1 id="tabelLabel" >Категории</h1>
        <p>На этой странице отображены данные полученные с сервера.</p>
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
    const response = await fetch('https://localhost:7104/api/Categories/GetGlobalCategoriesWithCategories',
                        {
                            mode: 'cors',
                            method: "get",
                            headers: {
                                "Content-Type": "application/json"
                            },
                        });
    const data = await response.json();
    this.setState({ Categories: data, loading: false });
  }
}