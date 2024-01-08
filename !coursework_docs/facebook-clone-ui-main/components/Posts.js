// import React, { useEffect } from "react";
// import Post from "./Post";
// import { useDispatch, useSelector } from "react-redux";
// import { addAllPost, selectPost } from "../public/src/features/postSlice";
// import axios from "axios";


// const Posts = () => {
//   const FACEBOOK_CLONE_URL_ENDPOINT = "http://localhost:9008/api/v1/post";  
//   const dispatch = useDispatch();
//   const posts = useSelector(selectPost);
//   useEffect(() => {
//     const fetchData = () => {
//       const response = axios
//         .get(FACEBOOK_CLONE_URL_ENDPOINT)
//         .then((response) => {
//           dispatch(addAllPost(response.data)); //we dispatch data from all our state
//         });
//     };
//     fetchData();
//   }, []);
//   return (
//     <div>
//       {posts.map((post) => (
//         <Post post={post} key={post.id} />
//       ))}
//     </div>
//   );
// };

// export default Posts;



import axios from "axios";
import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { addAllPost, selectPost } from "../public/src/features/postSlice";
import Post from "./Post";

const Posts = () => {
  const dispatch = useDispatch();
  const posts = useSelector(selectPost);
  useEffect(() => {
    const fetchData = () => {
      const response = axios
        .get("http://localhost:9008/api/v1/post")
        .then((response) => {
          console.log(response.data);
          dispatch(addAllPost(response.data));
        });
    };
    fetchData();
    console.log(posts);
  }, []);

  return (
    <div>
      {posts.map((post) => (
        <Post post={post} key={post.id} />
      ))}
    </div>
  );
};

export default Posts;