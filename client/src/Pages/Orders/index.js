import { Avatar, Space, Table, Typography } from "antd";
import { useEffect, useState } from "react";
import { getOrderList } from "../../api";

function Orders() {
  const [loading, setLoading] = useState(false);
  const [dataSource, setDataSource] = useState([]);

  useEffect(() => {
    setLoading(true);
    getOrderList(1, 30).then((res) => {
      setDataSource(res.data.items);
      setLoading(false);
      console.log(res);
    });
  }, []);

  return (
    <Space size={20} direction="vertical">
      <Typography.Title level={4}>Customers</Typography.Title>
      <Table
        loading={loading}
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
        pagination={{
          pageSize: 5,
        }}
      ></Table>
    </Space>
  );
}
export default Orders;
