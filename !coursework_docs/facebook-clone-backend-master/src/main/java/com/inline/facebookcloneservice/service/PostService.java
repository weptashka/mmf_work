package com.inline.facebookcloneservice.service;

import com.inline.facebookcloneservice.model.Post;
import org.springframework.web.multipart.MultipartFile;

import java.util.List;

public interface PostService {
    Post addPost(Post post) throws Exception;
    List<Post> getPost();
}
