import { Avatar, Space, Table, Typography } from "antd";
import { useEffect, useState } from "react";
import { getCustomerList } from "../../api";

function Customers() {
  const [loading, setLoading] = useState(false);
  const [dataSource, setDataSource] = useState([]);
  const [tableParams, setTableParams] = useState({
    pagination: {
      current: 1,
      pageSize: 30,
    },
  });

  const fetchData = () => {
    setLoading(true);
    getCustomerList(
      tableParams.pagination.current,
      tableParams.pagination.pageSize
    ).then((res) => {
      setDataSource(res.data.items);
      setLoading(false);
      console.log(res);
      setTableParams({
        pagination: {
          total: 90,
        },
      });
    });
  };
  useEffect(() => {
    fetchData();
  }, []);
  // const handleTableChange = (pagination) => {
  //   setTableParams({
  //     pagination: {
  //       ...pagination,
  //     },
  //   });
  // };

  return (
    <Space size={20} direction="vertical">
      <Typography.Title level={4}>Customers</Typography.Title>
      <Table
        loading={loading}
        pagination={tableParams.pagination}
        // onChange={handleTableChange}
        columns={[
          {
            title: "CustID",
            dataIndex: "customerId",
          },
          {
            title: "Name",
            dataIndex: "name",
          },
          {
            title: "Country",
            dataIndex: "country",
          },
          {
            title: "State",
            dataIndex: "state",
          },
          {
            title: "Zip",
            dataIndex: "zip",
          },

          {
            title: "City",
            dataIndex: "city",
          },

          {
            title: "address",
            dataIndex: "address",
            // render: (address) => {
            //   return (
            //     <span>
            //       {address.address}, {address.city}
            //     </span>
            //   );
            // },
          },
        ]}
        dataSource={dataSource}
        // pagination={{
        //   pageSize: 30,
        // }}
      ></Table>
    </Space>
  );
}
export default Customers;
