import { BellFilled, MailOutlined } from "@ant-design/icons";
import { Badge, Image, Space, Typography } from "antd";

function AppHeader() {
  return (
    // <div className="AppHeader">
    <Typography.Title>
      <div className="buttonContainer">
        <div className="searchButtonContainer">
          <button style={{ fontSize: 15 }} className="searchButton">
            搜尋
          </button>
        </div>
        <div className="addButtonContainer">
          <button style={{ fontSize: 15 }} className="addButton">
            新增資料
          </button>
        </div>
      </div>
    </Typography.Title>
    // </div>
    //   {/* <Space>
    //     <Badge count={3}>
    //       <MailOutlined style={{ fontSize: 24 }} />
    //     </Badge>
    //     <Badge count={15}>
    //       <BellFilled style={{ fontSize: 24 }} />
    //     </Badge>
    //   </Space> */}
    // </div>
  );
}
export default AppHeader;
